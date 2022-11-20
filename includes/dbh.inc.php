<?php

$serverName = "localhost";
$dBUsername = "root";
$dBPassword = "";
$dBName = "schooldbproject";

$conn = mysqli_connect($serverName,$dBUsername,$dBPassword,$dBName);

if (!$conn){
    die("Connection failed: " . sqlsrv_connect_error());
}

