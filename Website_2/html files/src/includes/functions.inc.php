<?php

function emptyInputSignup($name,$email,$username,$pwd,$pwdRepeat){
    $result;
    if (empty($name) || empty($email) || empty($username) || empty($pwd) || empty($pwdRepeat) ) {
        $result = true;
    }else{
        $result = false;
    }
    return $result;
}

function invalidUid($username){
    $result;
    if (!preg_match("/^[a-zA-Z0-9]*$/", $username)) {
        $result = true;
    }else{
        $result = false;
    }
    return $result;
}

function invalidEmail($email){
    $result;
    if (!filter_var($email,FILTER_VALIDATE_EMAIL)) {
        $result = true;
    }else{
        $result = false;
    }
    return $result;
}

function pwdMatch($pwd,$pwdRepeat){
    $result;
    if ($pwd !== $pwdRepeat) {
        $result = true;
    }else{
        $result = false;
    }
    return $result;
}

function uidExists($conn,$username,$email){
    $sql = "SELECT * FROM Student WHERE Username = '".$username."' OR std_Email = '".$username."';";
    // prevent sql injection
    // $stmt = sqlsrv_stmt_init($conn);
    // if (!sqlsrv_stmt_prepare($stmt,$sql)) {
    //     header("location: ../signup.php?error=stmtfailed");
    //     exit();
    // }

    // sqlsrv_stmt_bind_param($stmt,"ss", $username,$email);
    // sqlsrv_stmt_execute($stmt);
    // $resultData = sqlsrv_stmt_get_result($stmt);
    // if($row = sqlsrv_fetch_assoc($resultData)){
    //     return $row;
    // }else{
    //     $result = false;
    //     return $result;
    // }
    // sqlsrv_stmt_close($stmt);

    $stmt = sqlsrv_query($conn,$sql);
    if($stmt===false){
        echo 'Error in executing query';
        die(print_r(sqlsrv_errors(),true));
    }
    if($row = sqlsrv_fetch_array($stmt)){
        return $row;
    }else{
        $result = false;
        return $result;
    }
    sqlsrv_free_stmt($stmt);
    sqlsrv_close($conn);

}

function createUser($conn, $name,$email,$username,$pwd){
    $sql = "INSERT INTO users (usersName,usersEmail,usersUid,usersPwd) VALUES (?,?,?,?);";
    // prevent sql injection
    $stmt = sqlsrv_stmt_init($conn);
    if (!sqlsrv_stmt_prepare($stmt,$sql)) {
        header("location: ../signup.php?error=stmtfailed");
        exit();
    }

    // Hash Password for Security 
    // $hashedPwd = password_hash($pwd,PASSWORD_DEFAULT);

    sqlsrv_stmt_bind_param($stmt,"ssss", $name,$email,$username,$pwd);
    sqlsrv_stmt_execute($stmt);
    sqlsrv_stmt_close($stmt);
    header("location: ../signup.php?error=none");
    exit();

}


function emptyInputLogin($username,$pwd){
    $result;
    if (empty($username) || empty($pwd) ) {
        $result = true;
    }else{
        $result = false;
    }
    return $result;
}

function loginUser($conn,$username,$pwd){
    // this would work if enter username or email 
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
        Where (Username = '" . $username . "' or std_Email = '" . $username . "')
        AND Student.std_ID=Enrollment.std_ID";
        $stmt = sqlsrv_query($conn,$sql);
        $_SESSION["class_count"] = sqlsrv_fetch_array($stmt);
        $_SESSION["username"] = $username;
        
        // Super global session vars 
        $_SESSION["usersName"] = $uidExists["std_Name"];
        $_SESSION["usersMobile"] = $uidExists["std_Mobile"];
        // echo $_SESSION["usersName"];
        header("location: ../Dashboard.php");
        // exit();
    }

}