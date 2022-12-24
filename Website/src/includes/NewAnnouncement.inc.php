<?php

include_once '../header.php';

if(isset($_POST["new-ann"])){
    
    $posttext = $_POST["ann-text"];
    
    require_once 'dbh.inc.php';
    require_once 'functions.inc.php';
    
    // Error handling 
    if (empty($posttext)) {
        header('location: ../Announcement.php');
        exit();
    }

    if (makeNewAnnouncement($conn, $posttext)) {
    header('location: ../Announcement.php?ann=success');
    }else{
        header('location: ../Announcement.php?error=NOTPOSTED');
    }
}else{
    header('location: ../Announcement.php?error=FORM_NOT_SUBMITTED');
}
