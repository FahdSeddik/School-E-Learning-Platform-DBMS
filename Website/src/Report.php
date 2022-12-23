<?php
    include_once 'header.php';
    include_once 'LOGCHECK.php';
    require_once 'includes/functions.inc.php';
    require_once 'includes/dbh.inc.php';
    if($_SESSION["STUDENT"]==0){
        header("location: Dashboard.php?error=NO_REPORT_FOR_TEACHER");
        exit();
    }
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../dist/output.css" rel="stylesheet">
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
            $grades = getTranscript($conn);
            if(count($grades)<=0){
                echo '<div class="card ml-50 w-100">';
                echo '<h5 class="card-header w-100">No Grades Yet!</h5></div><hr>';
            }else{
                echo '<div class="card ml-50 w-75">';
                echo '<h5 class="card-header w-100">Grades</h5><div class="card-body">';
                $y = -1;
                foreach($grades as $grade){
                    if ($y !== $grade[0]) {
                        $y = $grade[0];
                        echo '<hr><br>';
                        echo '<h2>Year: ' . $grade[0] . '</h2>';
                        echo '<hr>';
                    }
                    echo '<div class="card rounded w-50 ml-5">';
                    echo "<h6>Subject: ".ucwords($grade[1])."</h6><h6>Grade: ".$grade[2]."</h6>";
                    echo '</div><br>';
                }
                echo '</div></div><br><br>';
            }
            ?>

            </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="index.js"></script>

</body>
</html>



