<?php

include_once '../header.php';

if(isset($_POST["upload-grades"]) && file_exists($_FILES['file']['tmp_name']) && is_uploaded_file($_FILES['file']['tmp_name'])){
    
    require_once 'dbh.inc.php';
    require_once 'functions.inc.php';

    $filename=$_FILES["file"]["tmp_name"];
    if ($_FILES["file"]["size"] > 0) {
        $file = fopen($filename, "r");
        $size = 0;
        $success = 0;
        $errorqueries = array();
        $getData = fgetcsv($file, 10000, ","); //skip header
        while (($getData = fgetcsv($file, 10000, ",")) !== FALSE) {
            $params = array($getData[4],$getData[5],$getData[0],$getData[2]);
            $size++;
            if(DoesTeach($conn,$getData[0]) && UpdateGrade($conn,$params)){
                $success++;
            }else{
                array_push($errorqueries, array($size,$getData));
            }
        }
        fclose($file);
        $_SESSION["G_S"] = array($success,$size,$errorqueries); //succeeded , total size , errorqueries (index, (entries) )
        header("location: ../Report.php?updated=1");
        exit();
    }else{
        header("location : ../Report.php?error=EMPTY_FILE");
        exit();
    }

}else{
    header("location: ../Report.php?error=FORM_NOT_SUBMITTED");
    exit();
}
