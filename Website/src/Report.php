<?php
    include_once 'header.php';
    include_once 'LOGCHECK.php';
    require_once 'includes/functions.inc.php';
    require_once 'includes/dbh.inc.php';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../dist/output.css" rel="stylesheet">
    <link rel="icon" href="assets/menu/report.png">
    <title>Full Transcript</title>
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v3.0.6/css/line.css">
    <link rel="stylesheet" href="	https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

</head>
<body class='bg-gray-800'>
    <div class=' ml-72 p-4  bg-gray-800 w-auto h-100 '>
            <div class=' relative mw-100'>
            <h1 class='text-gray-400'>Report</h1>
            
            <?php
            // 1    Art     A       0
            if ($_SESSION["STUDENT"]) {
                $grades = getTranscript($conn);
                if (count($grades) <= 0) {
                    echo '<div class="card ml-50 w-100">';
                    echo '<h5 class="card-header w-100">No Grades Yet!</h5></div><hr>';
                } else {
                    echo '<div class="card ml-50 w-75">';
                    echo '<h5 class="card-header w-100">Grades</h5><div class="card-body">';
                    $y = -1;
                    foreach ($grades as $grade) {
                        if ($y !== $grade[0]) {
                            $y = $grade[0];
                            echo '<hr><br>';
                            echo '<h2>Year: ' . $grade[0] . '</h2>';
                            echo '<hr>';
                        }
                        echo '<div class="card rounded w-50 ml-5">';
                        echo "<h6>Subject: " . ucwords($grade[1]) . "</h6><h6>Grade: " . $grade[2] . "</h6><h6>Coursework: " . $grade[3] . "</h6>";
                        echo '</div><br>';
                    }
                    echo '</div></div><br><br>';
                }
            }else{
                echo '<div class="card ml-50 w-75">';
                echo '<h5 class="card-header w-100">Upload Grades</h5>';
                $subjects = getSubjectNames($conn);//0 id 1 dep 2 name
                echo '<div class="card-body"><div class="card rounded w-100">';
                echo '<h3 >Download Subject Based Data (.csv)</h3><hr>';
                echo '<form id="f1" name="f1" method="post" action="includes/csv_download.php" class="m-3">';
                echo "<h4>Available Subjects</h4><select title='Available_Subjects' Name='subject' class='border'>";
                echo '<option value="">--- Select ---</option> '; 
                foreach($subjects as $subject){
                    echo '<option value="'.$subject[0].'">'.$subject[2];
                    echo '</option>';
                }
                echo '</select>';
                echo '<button type="submit" name="d_class_list" class="btn btn-primary button-loading m-3" data-loading-text="Loading...">Download class list</button>';
                echo '</form></div></div><br>';

                echo '<div class="card-body"><div class="card rounded w-100">';
                echo '<form class="form-horizontal" action="includes/csv_reader.php" method="post" name="upload_excel" enctype="multipart/form-data">';
                echo '<h3>Upload Data (.csv)</h3><hr><div class="col-md-5 w-100">';
                echo '<p>Please download class list and submit with same format</p>';
                echo '<div class="form-group"><h4>Grades (.csv)</h4>';
                echo '<input type="file" name="file" id="file" class="input-large m-2">';
                echo '<div class="col-md-4 m-1">';
                echo '<button type="submit" id="submit" name="upload-grades" class="btn btn-primary button-loading" data-loading-text="Loading...">Upload & Update</button>';
                echo '</div></div></div></form>';
                if(isset($_GET["updated"]) && isset($_SESSION["G_S"])){
                    $success = $_SESSION["G_S"][0];
                    $size = $_SESSION["G_S"][1];
                    $errorqueries = $_SESSION["G_S"][2];
                    echo '<div class="card rounded w-50 ml-5">';
                    echo "<h3>Executed: " . $success . "/".$size. "</h3>";
                    echo '</div><br>';
                    if($success!==$size){
                        foreach($errorqueries as $error){
                            echo '<div class="card rounded w-50 ml-5">';
                            echo "<h6>On index: " . $error[0]. "</h6>";
                            echo '<h6>Attributes:</h6>';
                            echo '<p>';
                            foreach($error[1] as $att){
                                echo $att.', ';
                            }
                            echo '</div><br>';
                        }
                    }
                    unset($_SESSION['G_S']);
                }
                echo '</div>';
            }
            ?>

            </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="index.js"></script>

</body>
</html>



