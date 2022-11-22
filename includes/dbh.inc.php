<?php

// $dBUsername = "DESKTOP-BVFC9IT'\'fahds";
// $dBPassword = "";
// $dBName = "SchoolDBMS";
$connectionInfo = array("UID"=>"","PWD"=>"","Database"=>"SchoolDBMS");
$serverName = "DESKTOP-BVFC9IT";
$conn = sqlsrv_connect($serverName,$connectionInfo);
if (!$conn){
    die(print_r(sqlsrv_errors(), true));
}

