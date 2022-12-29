<?php

include_once '../header.php';
require_once 'dbh.inc.php';
require_once 'functions.inc.php';

$nreqs = getNumberRequests($conn);
for ($i = 0; $i < $nreqs; $i++) {
    if (isset($_POST["delete-request".$i])) {
        $reqID = $_POST["reqID".$i];
        if (DeleteRequest($conn, array($reqID))) {
            header("location: ../Contact.php?delete=success");
            exit();
        }
        header("location: ../Contact.php?error=NOT_DELETED");
        exit();
    }
    if(isset($_POST["reply-request".$i])){
        $_SESSION["sender"] = $_POST["sender" . $i];
        $_SESSION["reqID"] = $_POST["reqID" . $i];
        header("location: ../Reply_Request.php?e=".$_SESSION["reqID"]);
        exit();
    }
}
header("location: ../Contact.php?error=FORM_NOT_SUBMITTED");
exit();