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

        //get courses
        $sql = "SELECT COUNT(*)
        FROM Student,Enrollment
        Where (Username = ? or std_Email = ?)
        AND Student.std_ID=Enrollment.std_ID";
        $params = array($username, $username);
        $stmt = sqlsrv_query($conn,$sql,$params);
        $_SESSION["class_count"] = sqlsrv_fetch_array($stmt);
        $_SESSION["username"] = $username;
        $sql = "SELECT std_SSN From Student Where Username= ?";
        $params = array($username);
        $stmt = sqlsrv_query($conn,$sql,$params);
        $_SESSION["SSN"] = sqlsrv_fetch_array($stmt);
        $_SESSION["CONN"] = $conn;
        
        header("location: ../Dashboard.php");
        // exit();
    }

}

function getSubjectNames($conn,$username){
    $subjectNames = array();
    
    $sql = "SELECT sub_Name,sub_Dep_Name
    From Subject,Student,Current_Student
    Where  Current_Student.std_Year=sub_Year and Student.std_ID=Current_student.std_ID and Student.Username=?";
    $stmt = sqlsrv_query($conn,$sql,array($username));
    while($row = sqlsrv_fetch_array($stmt)){
        array_push($subjectNames, $row);
    }
    return $subjectNames;
}