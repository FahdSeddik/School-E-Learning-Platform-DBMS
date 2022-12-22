<?php

// $dBUsername = "DESKTOP-BVFC9IT'\'fahds";
// $dBPassword = "";
// $dBName = "SchoolDBMS";
// $connectionInfo = array("UID"=>"","PWD"=>"","Database"=>"SchoolDBMS");
// $serverName = "DESKTOP-BVFC9IT";
// $conn = sqlsrv_connect($serverName,$connectionInfo);
// if (!$conn){
//     die(print_r(sqlsrv_errors(), true));
// }


$connectionInfo = array("UID" => "fahdseddik", "pwd" => "CMPN202Hello", "Database" => "School_DBMS", "LoginTimeout" => 30, "Encrypt" => 1, "TrustServerCertificate" => 0);
$serverName = "tcp:cmpn202-schooldbms.database.windows.net,1433";
$conn = sqlsrv_connect($serverName, $connectionInfo);
if (!$conn){
    die(print_r(sqlsrv_errors(), true));
}