<?php

function uidExists($conn,$username,$email){
    $sql = "SELECT * FROM Student WHERE Username = ? OR std_Email = ?;";
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
        $result = false;
        //sqlsrv_free_stmt($stmt);
        return $result;
    }
    //sqlsrv_free_stmt($stmt);
    //sqlsrv_close($conn);
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
        $sql = "SELECT std_SSN From Student Where Username= ?";
        $params = array($username);
        $stmt = sqlsrv_query($conn,$sql,$params);
        if (sqlsrv_fetch($stmt) === true) {
            $_SESSION["SSN"] = sqlsrv_get_field($stmt, 0);
        }else{
            $_SESSION["SSN"] = 'baka';
        }
        header("location: ../Dashboard.php"/*?ssn=".$_SESSION["SSN"]*/);
        // exit();
    }

}

function getSubjectNames($conn,$username){
    $subjectNames = array();
    
    $sql = "SELECT sub_Num,sub_Dep_Name,sub_Name
    From Subject,Student,Current_Student
    Where  Current_Student.std_Year=sub_Year and Student.std_ID=Current_student.std_ID and Student.Username=?";
    $stmt = sqlsrv_query($conn,$sql,array($username));
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($subjectNames, $row);
    }
    return $subjectNames;
}


function makeNewPost($conn,$posttext){
    
    $sql = "INSERT INTO Posts(sub_Num,sub_Dep_Name,SSN,Post,Date)
    VALUES(".$_SESSION["sub_Num"].",'".$_SESSION["sub_Dep_Name"]."','".$_SESSION["SSN"]."','".$posttext."',SYSDATETIME())";
    $stmt = sqlsrv_prepare($conn, $sql);
    return sqlsrv_execute($stmt);
}


// function getName($conn,$ssn){
//     $sql = "((SELECT staff_Name
//     From Staff
//     WHERE EXISTS
//     (SELECT staff_Name FROM Staff WHERE staff_SSN=".$ssn.") and staff_SSN=".$ssn.")
//     UNION
//     (SELECT std_Name
//     FROM Student
//     WHERE EXISTS
//     (SELECT std_Name FROM Student WHERE std_SSN=".$ssn.") and std_SSN=".$ssn."));";
//     $stmt = sqlsrv_query($conn, $sql);
//     $res = sqlsrv_fetch($stmt);
//     return $res;
// }

function getPosts($conn){
    $posts = array();




    $sql = "SELECT Date,SSN 
    FROM Posts 
    Where sub_Num=" . $_SESSION["sub_Num"] . " and sub_Dep_Name='" . $_SESSION["sub_Dep_Name"] . "'
    Order by Date Desc";
    $stmt = sqlsrv_query($conn, $sql);
    $ssns = array();
    while(sqlsrv_fetch( $stmt )===true && $ssn = sqlsrv_get_field( $stmt, 1)){
        if (!in_array($ssn, $ssns)) {
            array_push($ssns, $ssn);
        }
        //array_push($posts, array($ssn,'ka7yaan',$ssn));
    }
    foreach($ssns as $ssn){
        $sql = "SELECT Post,Date,std_Name
        FROM POSTS,Student 
        Where sub_Num=" . $_SESSION["sub_Num"] . " and sub_Dep_Name='" . $_SESSION["sub_Dep_Name"] . "' and std_SSN=SSN and SSN='".$ssn."' 
         Order by Date Desc";
        $stmt = sqlsrv_query($conn, $sql);
        if($stmt==false){
            $sql = "SELECT Post,Date,staff_Name
            FROM POSTS,Staff
            Where sub_Num=" . $_SESSION["sub_Num"] . " and sub_Dep_Name='" . $_SESSION["sub_Dep_Name"] . "' and staff_SSN=SSN and SSN='".$ssn."' 
             Order by Date Desc";
            $stmt = sqlsrv_query($conn, $sql);
            if ($stmt == false)
                continue;
            while ($post = sqlsrv_fetch_array($stmt)) {
                array_push($posts, $post);
            }
        }else{
            while ($post = sqlsrv_fetch_array($stmt)) {
                array_push($posts, $post);
            }
        }
    }
    return $posts;
}