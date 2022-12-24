<?php

include_once '../header.php';
require_once 'dbh.inc.php';
require_once 'functions.inc.php';

$nreqs = getNumberRequests($conn);
for ($i = 0; $i < $nreqs; $i++) {
    if (isset($_POST["delete-request".$i])) {
        $sender = $_POST["sender".$i];
        $receiver = $_POST["receiver".$i];
        $title = $_POST["title".$i];
        $request = $_POST["request".$i];
        $state = $_POST["state".$i];
        $date = $_POST["date".$i];
        if (DeleteRequest($conn, array($sender, $receiver, $title, $request, $state, $date))) {
            header("location: ../Contact.php?delete=success");
            exit();
        }
        header("location: ../Contact.php?error=NOT_DELETED");
        exit();
    }
    if(isset($_POST["reply-request".$i])){
        $_SESSION["sender"] = $_POST["sender" . $i];
        $_SESSION["title"] = $_POST["title" . $i];
        $_SESSION["request"] = $_POST["request" . $i];
        $_SESSION["state"] = $_POST["state" . $i];
        $_SESSION["date"] = $_POST["date" . $i];
        header("location: ../Reply_Request.php");
        exit();
    }
}
header("location: ../Contact.php?error=FORM_NOT_SUBMITTED".$nreqs);
exit();