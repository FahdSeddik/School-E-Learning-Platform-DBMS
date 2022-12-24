<?php

include_once '../header.php';

if(isset($_POST["new-post"])){

    $posttext = $_POST["post-text"];
    
    require_once '../includes/dbh.inc.php';
    require_once '../includes/functions.inc.php';
    
    // Error handling 
    if (empty($posttext)) {
        header('location: Subject.php?sub='. $_SESSION["sub_ID"]);
        exit();
    }

    if (makeNewPost($conn, $posttext)) {
    header('location: Subject.php?sub='. $_SESSION["sub_ID"]);
    }else{
        header('location: Subject.php?sub='. $_SESSION["sub_ID"].'&error=NOTPOSTED');
    }
}else{
    header('location: Subject.php?sub='. $_SESSION["sub_ID"]);
}
