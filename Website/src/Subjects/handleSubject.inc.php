<?php
require_once '../header.php';

if(!isset($_SESSION["username"])){
    header("location: ../includes/logout.inc.php");
    exit();
}

