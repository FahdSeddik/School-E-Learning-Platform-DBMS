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
        $sql = "SELECT Username,Password,staff_SSN as SSN FROM Staff WHERE Username = ? OR staff_Email = ?;";
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
    // Associate array (column names)
    // $pwdHashed = $uidExists["usersPwd"];
    // $checkPwd = password_verify($pwd,$pwdHashed);
    
    if($uidExists["Password"] !== $pwd){
        echo 'test';
        header("location: ../../index.php?error=wronglogin");
        exit();
    }else {
        // Allow session variables 
        session_start();

        $_SESSION["username"] = $username;
        $_SESSION["SSN"] = $uidExists["SSN"];
        if (isStudent($conn)==1)
            $_SESSION["STUDENT"] = 1;
        else
            $_SESSION["STUDENT"] = 0;
        header("location: ../Dashboard.php");
        // exit();
    }

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
        if ($row[0] == 'german')
            return 'french';
        else
            return 'german';
    }
    else
        return false;
}

function getTranscript($conn){
    $sql = "SELECT sub_Year,sub_Name,Grade
    From Subject,Enrollment,Student
    Where Student.std_ID=Enrollment.std_ID and Subject.sub_Num=Enrollment.sub_Num and Subject.sub_Dep_Name=Enrollment.sub_Dep_Name
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

function DoesTeach($conn){
    $sql = "SELECT *
    From Teach
    Where t_ID=? and sub_Num=? and sub_Dep_Name=?";
    $params = array(getTeacherID($conn), $_SESSION["sub_Num"], $_SESSION["sub_Dep_Name"]);
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
        return 0;
    if($row = sqlsrv_fetch_array($stmt)){
        return 1;
    }
    return 0;
}

function getStudentinSubject($conn){
    $sql = "SELECT std_Name
    From Student,Current_Student
    Where Current_Student.std_ID=Student.std_ID and std_Year=?";
    $params = array(getStudentYear($conn));
    $stmt = sqlsrv_query($conn, $sql, $params);
    if ($stmt == false)
        return array();
    $students = array();
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($students, ucwords($row[0]));
    }
    return $students;
}
function getSubjectNames($conn,$username){
    $subjectNames = array();
    if ($_SESSION["STUDENT"]==1) {
        $sql = "SELECT sub_Num,sub_Dep_Name,sub_Name
        From Subject,Student,Current_Student
        Where  Current_Student.std_Year=sub_Year and Student.std_ID=Current_student.std_ID and Student.Username=?";
        $stmt = sqlsrv_query($conn, $sql, array($username));
    }else{
        $sql = "Select Subject.sub_Num,Subject.sub_Dep_Name,Subject.sub_Name
        From Teach,Teacher,Subject
        Where staff_ID=t_ID and Teach.sub_Num=Subject.sub_Num and Teach.sub_Dep_Name=Subject.sub_Dep_Name and t_ID=?";
        $stmt = sqlsrv_query($conn, $sql, array(getTeacherID($conn)));
    }
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($subjectNames, $row);
    }
    return $subjectNames;
}

function getPastGrades($conn){
    $sql = "Select sub_Name,Grade,Count
    From 
    (SELECT sub_Num,sub_Dep_Name,Grade,Count(Grade) as Count
    From Enrollment
    Group by sub_Num,sub_Dep_Name,Grade) as E,Subject
    Where Subject.sub_Num=? and Subject.sub_Dep_Name=? and E.sub_num=Subject.sub_num and Subject.sub_dep_name=E.sub_dep_name";
    $params = array($_SESSION["sub_Num"], $_SESSION["sub_Dep_Name"]);
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
    Where sub_Num =?  and sub_Dep_Name=? and t_id=staff_id ";
    $params = array($_SESSION["sub_Num"], $_SESSION["sub_Dep_Name"]);
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
    $sql = "INSERT INTO Posts(sub_Num,sub_Dep_Name,SSN,Post,Date)
    VALUES(".$_SESSION["sub_Num"].",'".$_SESSION["sub_Dep_Name"]."','".$_SESSION["SSN"]."','".$posttext."',SYSDATETIME())";
    $stmt = sqlsrv_prepare($conn, $sql);
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

function getSubjectYear($conn,$sub_Num,$sub_Dep_Name){
    $sql = "SELECT sub_Year
    From Subject
    Where sub_Num=? and Sub_Dep_Name=?";
    $params = array($sub_Num,$sub_Dep_Name);
    $stmt = sqlsrv_query($conn, $sql, $params);
    $year = -1;
    if ($stmt == false)
        return -1;
    if(sqlsrv_fetch($stmt) === true){
        $year = sqlsrv_get_field($stmt, 0);
    }
    return $year;
}


function getPosts($conn){
    $posts = array();

    $sql = "SELECT Post,Date,SSN
    FRom Posts
    Where sub_Num=? and sub_Dep_Name=?
    Order by Date Desc";
    $params = array($_SESSION["sub_Num"],$_SESSION["sub_Dep_Name"]);
    $stmt = sqlsrv_query($conn, $sql,$params);
    while($post = sqlsrv_fetch_array($stmt)){
        array_push($posts, $post);
    }
    for($i = 0;$i <count($posts);$i++){
        $params = array($posts[$i][2]);
        $sql = "SELECT std_Name From Student Where std_SSN=?;";
        $stmt = sqlsrv_query($conn, $sql,$params);
        if(sqlsrv_fetch($stmt) == false){
            $sql = "SELECT staff_Name From Staff Where staff_SSN=?;";
            $stmt = sqlsrv_query($conn, $sql,$params);
            if (sqlsrv_fetch($stmt) === true) {
                $name = sqlsrv_get_field($stmt, 0);
                $posts[$i][2] = '*TEACHER* '. ucwords($name);
            }
        } else {
            $name = sqlsrv_get_field($stmt, 0);
            $posts[$i][2] = ucwords($name);
        }
    }
    return $posts;
}