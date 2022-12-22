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
    <title>Dashboard</title>  


</head>
<body>

        

        <div class=' ml-72 p-4  bg-gray-800  w-full' >
            <div class=' relative '>
                <h1 class='text-gray-400'>Dashboard</h1>
                <div class="">
                    <div class=" max-w-2xl py-16 px-4 sm:py-24 sm:px-6 lg:max-w-7xl lg:px-8">                
                        <!-- Div to add  -->
                        <div class="grid grid-cols-1 gap-y-10 gap-x-6 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 xl:gap-x-8 " id="add_sub">
                        <?php  
                        $subjectNames = getSubjectNames($conn, $_SESSION["username"]);
                        foreach ($subjectNames as $subject) {
                            echo '<a href="Subjects/Subject.php?Dep='.$subject[1].'&num='.$subject[0].'" class="group"><div class="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8">';
                            echo '<img src="../src/assets/subject/' . $subject[1] . '.png" alt="0" class="h-full w-full object-cover object-center group-hover:opacity-75"/></div>';
                            echo '<h3 class="mt-4 text-2xl text-gray-400 ">' .ucfirst($subject[2]) . '</h3></a>';
                        }
                        ?>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="index.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    
</body>
</html>