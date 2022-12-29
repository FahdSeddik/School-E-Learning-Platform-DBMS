<?php

function uidExists($conn,$username,$email){
    $sql = "SELECT Username,Password,std_SSN as SSN FROM Student WHERE Username = ? OR std_Email = ?;";
    // prevent sql injection
    $params = array($username,$username);
    $stmt = sqlsrv_query($conn,$sql,$params);
    echo 'in uid';
    if($stmt===false){
        echo 'Error in executing query';
        die(print_r(sqlsrv_errors(),true));
    }
    if($row = sqlsrv_fetch_array($stmt)){
        echo 'Found';
        //sqlsrv_free_stmt($stmt);
        return $row;  
    }else{
        $sql = "SELECT Username,Password,staff_SSN as SSN,staff_ID FROM Staff WHERE staff_Position='Teacher' and Username = ? OR staff_Email = ?;";
        // prevent sql injection
        $params = array($username,$username);
        $stmt = sqlsrv_query($conn,$sql,$params);
        if($stmt===false){
            echo 'Error in executing query';
            die(print_r(sqlsrv_errors(),true));
        }
        if($row = sqlsrv_fetch_array($stmt)){
            echo 'Found';
            return $row;  
        }
    }
    return false;
}

function emptyInputLogin($username,$pwd){
    $result=0;
    if (empty($username) || empty($pwd) ) {
        $result = true;
    }else{
        $result = false;
    }
    return $result;
}

function loginUser($conn,$username,$pwd){
    // this would work if enter username or email
    //header("location: ../../index.php?error=we");
    
    $uidExists = uidExists($conn,$username,$username);

    // Error handler 
    if ($uidExists === false) {
        echo 'error handler';
        header("location: ../../index.php?error=wronglogin");
        exit();
    }
    if($uidExists["Password"]=="0000" && $uidExists["Password"]!==$pwd){
        header("location: ../../index.php?error=wronglogin");
        exit();
    }
    if($uidExists["Password"]=="0000"){
        session_start();
        $_SESSION["username"] = $username;
        header("location: ../../Reset_password.php");
        exit();
    }
    // Associate array (column names)
    $pwdHashed = $uidExists["Password"];
    $checkPwd = password_verify($pwd,$pwdHashed);
    
    if(!$checkPwd){
        header("location: ../../index.php?error=wronglogin");
        exit();
    }else {
        // Allow session variables 
        session_start();

        $_SESSION["username"] = $username;
        $_SESSION["SSN"] = $uidExists["SSN"];
        if (isStudent($conn) == 1) {
            $_SESSION["STUDENT"] = 1;
            $_SESSION["dephead"] = 0;
        }
        else {
            $_SESSION["STUDENT"] = 0;
            if (isDepHead($conn, $uidExists["staff_ID"])==1) {
                $_SESSION["dephead"] = 1;
            }
            else {
                $_SESSION["dephead"] = 0;
            }
        }
        header("location: ../Dashboard.php");
        // exit();
    }

}
function isDepHead($conn,$id){
    $sql = "SELECT *
    From Department
    Where dep_Head_ID=?";
    $params = array($id);
    $stmt = sqlsrv_query($conn,$sql,$params);
    if ($stmt == false)
        return 0;
    if (sqlsrv_fetch_array($stmt))
        return 1;
    return 0;

}
function isStudent($conn){
    $sql = "SELECT *
    From Student
    Where std_SSN=?";
    $params = array($_SESSION["SSN"]);
    $stmt = sqlsrv_query($conn,$sql,$params);
    if ($stmt == false)
        return 0;
    if (sqlsrv_fetch_array($stmt))
        return 1;
    return 0;
}

function getStdLangNOT($conn){
    $sql = "SELECT second_language
    From [dbo].[Student]
    Where std_SSN=?";
    $params = array($_SESSION["SSN"]);
    $stmt = sqlsrv_query($conn,$sql,$params);
    if ($stmt == false)
        return false;
    if ($row = sqlsrv_fetch_array($stmt)){
        if ($row[0] == 'German')
            return 'French';
        else
            return 'German';
    }
    else
        return false;
}

function getTranscript($conn){
    $sql = "SELECT sub_Year,sub_Name,Grade,Coursework
    From Subject,Enrollment,Student
    Where Student.std_ID=Enrollment.std_ID and Subject.sub_ID=Enrollment.sub_ID
    and Student.std_SSN=?
    Order by sub_Year,sub_Name,Grade";
    $params = array($_SESSION["SSN"]);
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
        return array();
    $grades = array();
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($grades, $row);
    }
    return $grades;
}

function getTeacherID($conn){
    $sql = "SELECT staff_ID
    From Staff
    Where staff_SSN=?";
    $stmt = sqlsrv_query($conn,$sql,array($_SESSION["SSN"]));
    if ($stmt == false)
        return 0;
    if($row = sqlsrv_fetch_array($stmt)){
        return $row[0];
    }
    return 0;
}

function DoesTeach($conn,$sub_ID){
    $sql = "SELECT *
    From Teach
    Where t_ID=? and sub_ID=?";
    $params = array(getTeacherID($conn),$sub_ID);
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
        return 0;
    if($row = sqlsrv_fetch_array($stmt)){
        return 1;
    }
    return 0;
}

function getStudentinSubject($conn){
    $sql = "SELECT std_Name,Student.std_ID
    From Student,Current_Student,Subject
    Where Current_Student.std_ID=Student.std_ID and sub_Year=std_Year and sub_ID=?";
    $params = array($_SESSION["sub_ID"]);
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
        return array();
    $students = array();
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($students, ucwords($row[0]));
    }
    return $students;
}
function getSubjectNames($conn){
    $subjectNames = array();
    if ($_SESSION["STUDENT"]==1) {
        $sql = "SELECT sub_ID,sub_Dep_Name,sub_Name
        From Subject,Student,Current_Student
        Where  Current_Student.std_Year=sub_Year and Student.std_ID=Current_student.std_ID and Student.std_SSN=?";
        $stmt = sqlsrv_query($conn, $sql, array($_SESSION["SSN"]));
    }else{
        $sql = "Select Subject.sub_ID,Subject.sub_Dep_Name,Subject.sub_Name
        From Teach,Teacher,Subject
        Where staff_ID=t_ID and Teach.sub_ID=Subject.sub_ID and t_ID=?";
        $stmt = sqlsrv_query($conn, $sql, array(getTeacherID($conn)));
    }
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($subjectNames, $row);
    }
    return $subjectNames;
}

function getPastGrades($conn){
    $sql = "SELECT Grade,Count(Grade) as Count
    From Enrollment
    Where sub_ID=? and NOT Grade='U'
    Group by Grade";
    $params = array($_SESSION["sub_ID"]);
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
        return array();
    $grade_counts = array();
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($grade_counts, $row);
    }
    return $grade_counts;
}


function getTeachersWhoTeach($conn){
    $sql = "SELECT staff_Name
    From Staff,Teach
    Where sub_ID =? and t_id=staff_id ";
    $params = array($_SESSION["sub_ID"]);
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
        return array();
    $teachers = array();
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($teachers, ucwords($row[0]));
    }
    return $teachers;
}

function makeNewPost($conn,$posttext){
    $posttext = nl2br($posttext);
    $sql = "INSERT INTO Posts(sub_ID,SSN,Post,Date)
    VALUES(?,?,?,SYSDATETIME())";
    $params = array($_SESSION["sub_ID"], $_SESSION["SSN"], $posttext);
    $stmt = sqlsrv_prepare($conn, $sql,$params);
    return sqlsrv_execute($stmt);
}


function getStudentYear($conn){
    $sql = "SELECT std_Year
    From Current_Student,Student
    Where Current_Student.std_ID=Student.std_ID and std_SSN=?";
    $params = array($_SESSION["SSN"]);
    $stmt = sqlsrv_query($conn, $sql, $params);
    $year = -1;
    if ($stmt == false)
        return -1;
    if(sqlsrv_fetch($stmt) === true){
        $year = sqlsrv_get_field($stmt, 0);
    }
    return $year;
}

function getSubjectYear($conn,$sub_ID){
    $sql = "SELECT sub_Year
    From Subject
    Where sub_ID=?";
    $params = array($sub_ID);
    $stmt = sqlsrv_query($conn, $sql, $params);
    $year = -1;
    if ($stmt == false)
        return -1;
    if(sqlsrv_fetch($stmt) === true){
        $year = sqlsrv_get_field($stmt, 0);
    }
    return $year;
}
function getDepName($conn){
    $sql = "SELECT sub_Dep_Name
    From Subject
    Where sub_ID=?";
    $params = array($_SESSION["sub_ID"]);
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
    return 'ERROR';
    $name = ' ';
    if(sqlsrv_fetch($stmt)===true){
        $name = sqlsrv_get_field($stmt, 0);
    }
    return $name;
}

function getPosts($conn){
    $posts = array();

    $sql = "SELECT Post_ID,Post,Date,SSN
    FRom Posts
    Where sub_ID=?
    Order by Date Desc";
    $params = array($_SESSION["sub_ID"]);
    $stmt = sqlsrv_query($conn, $sql,$params);
    while($post = sqlsrv_fetch_array($stmt)){
        array_push($posts, $post);
    }
    for($i = 0;$i <count($posts);$i++){
        $params = array($posts[$i][3]);
        $sql = "SELECT std_Name From Student Where std_SSN=?;";
        $stmt = sqlsrv_query($conn, $sql,$params);
        if(sqlsrv_fetch($stmt) == false){
            $sql = "SELECT staff_Name From Staff Where staff_SSN=?;";
            $stmt = sqlsrv_query($conn, $sql,$params);
            if (sqlsrv_fetch($stmt) === true) {
                $name = sqlsrv_get_field($stmt, 0);
                array_push($posts[$i],'*TEACHER* '. ucwords($name));
            }
        } else {
            $name = sqlsrv_get_field($stmt, 0);
            array_push($posts[$i],ucwords($name));
        }
    }
    return $posts;
}

function getSchedule($conn){
    //5 days per week
    $schedule = array(array(),array(),array(),array(),array());
    $days = array('Sunday','Monday','Tuesday','Wednesday','Thursday');
    if($_SESSION["STUDENT"]==1){
        $year = getStudentYear($conn);
        for($i=0;$i<count($days);$i++){
            $sql = "SELECT r_Building_Num,r_Floor,r_Num,sub_Name,Start_Time,End_Time,day
            From Subject_Time_Loc,Subject
            Where Subject.sub_ID=Subject_Time_Loc.sub_ID and day=? and sub_Year=?
            Order by Start_Time";
            $params = array($days[$i],$year);
            $stmt = sqlsrv_query($conn, $sql, $params);
            while($sb = sqlsrv_fetch_array($stmt)){
                array_push($schedule[$i], $sb);
            }
        }
    }else{
        $tid = getTeacherID($conn);
        for($i=0;$i<count($days);$i++){
            $sql = "SELECT r_Building_Num,r_Floor,r_Num,sub_Name,Start_Time,End_Time,day
            From Subject_Time_Loc,Subject
            Where Subject.sub_ID=Subject_Time_Loc.sub_ID and day=? and Subject_Time_Loc.t_ID=?
            Order by Start_Time";
            $params = array($days[$i],$tid);
            $stmt = sqlsrv_query($conn, $sql, $params);
            while($sb = sqlsrv_fetch_array($stmt)){
                array_push($schedule[$i], $sb);
            }
        }
    }
    return $schedule;
}

function getClassList_WithGrades($conn,$sub_ID){
    $sql = "SELECT Enrollment.sub_ID,sub_Name,Student.std_ID,std_Name,Grade,Coursework
    From Student,Enrollment,Subject,Current_Student
    Where Subject.sub_ID=Enrollment.sub_ID and Current_Student.std_ID=Enrollment.std_ID
     and Student.std_ID=Enrollment.std_ID  and std_Year=sub_Year and Enrollment.sub_ID=?
     order by std_Name";
    $params = array($sub_ID);
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
        return array();
    $class = array();
    while($row = sqlsrv_fetch_array($stmt,SQLSRV_FETCH_ASSOC)){
        array_push($class, $row);
    }
    return $class;
}

function UpdateGrade($conn,$params){
    foreach($params as $param){
        if (empty($param))
            return false;
    }
    $sql = "UPDATE Enrollment
    SET Grade = ?,Coursework=?
    Where sub_ID=? and std_ID=?";
    $stmt = sqlsrv_prepare($conn, $sql,$params);
    if (sqlsrv_execute($stmt))
        return true;
    return false;
}


function getTeachers($conn){
    $sql = "SELECT staff_SSN,Staff_Name,staff_Email
    From Teach,Staff
    Where t_id=staff_ID and sub_ID in
    (SELECT sub_ID
    From Subject,Student,Current_Student
    Where  Current_Student.std_Year=sub_Year and Student.std_ID=Current_student.std_ID and Student.std_SSN=?)";
    $stmt = sqlsrv_query($conn, $sql, array($_SESSION["SSN"]));
    $teachers = array();
    while($t = sqlsrv_fetch_array($stmt)){
        array_push($teachers, $t);
    }
    return $teachers;
}


function getAdmins($conn){
    $sql = "Select staff_SSN,staff_Name,staff_Email
    From Staff
    Where staff_levelAuth=1";
    $stmt = sqlsrv_query($conn, $sql);
    $admins = array();
    while ($row = sqlsrv_fetch_array($stmt)){
        array_push($row, '(Admin)');
        array_push($admins, $row);
    }
    return $admins;
}

function sendRequest($conn,$params){
    $sql = "INSERT INTO Request VALUES(?,?,?,?,-1,SYSDATETIME())";
    $stmt = sqlsrv_prepare($conn, $sql, $params);
    if (sqlsrv_execute($stmt))
        return true;
    return false;
}
function getInbox($conn){
    $sql = "SELECT staff_Name,staff_Email,title,request,state,date,sender,Request_ID
    fROM REQUEST,Staff
    where receiver=? and sender=Staff.staff_SSN
    order by date desc";
    $inbox = array();
    $stmt = sqlsrv_query($conn, $sql, array($_SESSION["SSN"]));
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($inbox, $row);
    }
    $sql = "SELECT std_Name,std_Email,title,request,state,date,sender,Request_ID
    fROM REQUEST,Student
    where receiver=? and sender=std_SSN
    order by date desc";
    $stmt = sqlsrv_query($conn, $sql, array($_SESSION["SSN"]));
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($row, 1);
        array_push($inbox, $row);
    }
    return $inbox;
}
function DeleteRequest($conn,$params){
    $sql = "Delete from request
    Where request_ID = ?";
    $stmt = sqlsrv_prepare($conn, $sql, $params);
    if (sqlsrv_execute($stmt))
        return true;
    return false;
}
function getNumberRequests($conn){
    $sql = "SELECT Count(*)
    fROM REQUEST
    where receiver=?";
    $stmt = sqlsrv_query($conn,$sql,array($_SESSION["SSN"]));
    return sqlsrv_fetch_array($stmt)[0];
}

function UpdateRequestStatus($conn,$p1,$p2){
    $sql = "UPDATE Request
    Set state=?
    Where request_ID=?";
    $stmt = sqlsrv_prepare($conn,$sql,$p1);
    if(!sqlsrv_execute($stmt))return 2;
    $sql = "INSERT INTO Request VALUES(?,?,?,?,?,SYSDATETIME())";
    $stmt = sqlsrv_prepare($conn,$sql,$p2);
    if(!sqlsrv_execute($stmt))return 1;
    return 0;
}

function makeNewAnnouncement($conn,$posttext){
    $sql = "INSERT INTO Announcement VALUES(?,?,SYSDATETIME())";
    $stmt = sqlsrv_prepare($conn, $sql, array($_SESSION["SSN"], $posttext));
    return sqlsrv_execute($stmt);
}

function getAnnouncements($conn){
    $sql = "SELECT staff_Name,Post,Date,Ann_ID,SSN
    From Staff,Announcement
    where staff_SSN=SSN
    ORder by date desc";
    $stmt = sqlsrv_query($conn, $sql);
    $ann = array();
    while($a = sqlsrv_fetch_array($stmt)){
        array_push($ann, $a);
    }
    return $ann;
}

function UpdatePassword($conn,$pwd){
    $sql = "Update Student set password=? where username=?";
    // Hash Password for Security 
    $hashedPwd = password_hash($pwd,PASSWORD_DEFAULT);
    $stmt = sqlsrv_prepare($conn, $sql, array($hashedPwd, $_SESSION["username"]));
    if (!sqlsrv_execute($stmt))
        return 2;
    $sql = "Update Staff set password=? where username=?";
    $stmt = sqlsrv_prepare($conn, $sql, array($hashedPwd, $_SESSION["username"]));
    if (!sqlsrv_execute($stmt))
        return 3;
    return 0;
}


function getUserDetails($conn,$username,$email){
    $sql = "SELECT std_Email,Username,Password From Student where std_Email=? OR username=?";
    $stmt = sqlsrv_query($conn, $sql, array($email, $username));
    if($row = sqlsrv_fetch_array($stmt)){
        return $row;
    }
    $sql = "SELECT staff_Email,Username,Password From Staff where staff_Email=? OR username=?";
    $stmt = sqlsrv_query($conn, $sql, array($email, $username));
    if($row = sqlsrv_fetch_array($stmt)){
        return $row;
    }
    return false;
}

function getPostsIDs($conn){
    $sql = "SELECT post_ID From Posts where sub_ID=?";
    $stmt = sqlsrv_query($conn, $sql, array($_SESSION["sub_ID"]));
    $ids = array();
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($ids, $row[0]);
    }
    return $ids;
}

function DeletePost($conn,$post_ID){
    $sql = "Delete from Posts where post_ID=?";
    $stmt = sqlsrv_prepare($conn, $sql, $post_ID);
    return sqlsrv_execute($stmt);
}


function DeleteAnn($conn,$ann_ID){
    $sql = "Delete from Announcement where ann_ID=?";
    $stmt = sqlsrv_prepare($conn, $sql, array($ann_ID));
    return sqlsrv_execute($stmt);
}


function getAnnIDs($conn){
    $sql = "SELECT Ann_ID From Announcement";
    $stmt = sqlsrv_query($conn, $sql);
    $ids = array();
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($ids, $row[0]);
    }
    return $ids;
}