<?php

include_once '../header.php';
require_once 'dbh.inc.php';
require_once 'functions.inc.php';

$ids = getPostsIDs($conn);
foreach ($ids as $id) {
    if (isset($_POST["delete-post".$id])) {
        $post_ID = $_POST["post".$id];
        if (DeletePost($conn, array($post_ID))) {
            header("location: ../Subjects/Subject.php?sub=".$_SESSION["sub_ID"]."&delete=success");
            exit();
        }
        header("location: ../Subjects/Subject.php?sub=".$_SESSION["sub_ID"]."&delete=ERROR");
        exit();
    }
}
header("location: ../Subjects/Subject.php?sub=".$_SESSION["sub_ID"]."&error=FORM_NOT_SUBMITTED");
exit();