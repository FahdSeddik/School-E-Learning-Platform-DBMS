<?php

include_once '../header.php';

if (isset($_POST["d_class_list"]) && !empty($_POST["subject"])) {
    require_once 'dbh.inc.php';
    require_once 'functions.inc.php';
    header('Content-Type: text/csv; charset=utf-8');  
    header('Content-Disposition: attachment; filename='.$_POST["subject"].' - Class List.csv');  
    ob_clean();
    $output = fopen("php://output", "w");  
    fputcsv($output, array('sub_ID','sub_Name','std_ID', 'std_Name', 'Grade','Coursework'));
    

    $class = getClassList_WithGrades($conn, $_POST["subject"]);
    foreach($class as $student)
    {  
        fputcsv($output, $student);  
    }  
    fclose($output);

}
else{
    header("location: ../Report.php?error=FORM_NOT_SUBMITTED");
    exit();
}