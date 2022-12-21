<?php


if(isset($_POST["new-post"])){

    $posttext = $_POST["post-text"];
    
    include_once '../header.php';
    require_once '../includes/dbh.inc.php';
    require_once '../includes/functions.inc.php';
    
    // Error handling 
    if (empty($posttext)) {
        header(join("",array('location: ../Dashboard.php?',$posttext)));
        exit();
    }

    if (makeNewPost($conn, $posttext)) {
    header(join("", array('location: Subject.php?Dep=', $_SESSION["sub_Dep_Name"], '&num=', $_SESSION["sub_Num"]/*, '&ssn=', $_SESSION["SSN"]*/)));
    }else{
        header(join("", array('location: Subject.php?Dep=', $_SESSION["sub_Dep_Name"], '&num=', $_SESSION["sub_Num"], '&error=NOTPOSTED',)));
    }
}else{
    header(join("",array('location: Subject.php?Dep=',$_SESSION["sub_Dep_Name"],'&num=',$_SESSION["sub_Num"])));
}
