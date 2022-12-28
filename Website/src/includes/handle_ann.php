<?php

include_once '../header.php';
require_once 'dbh.inc.php';
require_once 'functions.inc.php';

$ids = getAnnIDs($conn);
foreach ($ids as $id) {
    if (isset($_POST["delete-ann".$id])) {
        $post_ID = $_POST["ann".$id];
        if (DeleteAnn($conn, array($post_ID))) {
            header("location: ../Announcement.php?delete=success");
            exit();
        }
        header("location: ../Announcement.php?delete=ERROR");
        exit();
    }
}
header("location: ../Announcement.php?&error=FORM_NOT_SUBMITTED");
exit();