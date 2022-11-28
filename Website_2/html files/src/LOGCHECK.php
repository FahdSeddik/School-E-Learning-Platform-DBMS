<?php
if(!isset($_SESSION["usersName"])){
    header("location: ../index.php");
    exit();
}
?>