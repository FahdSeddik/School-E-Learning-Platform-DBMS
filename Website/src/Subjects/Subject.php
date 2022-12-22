<?php
    include_once '../header.php';
    include_once 'handleSubject.inc.php';
    require_once '../includes/functions.inc.php';
    require_once '../includes/dbh.inc.php';
    if(!isset($_GET["Dep"]) || !isset($_SESSION["username"])){
        header("location: ../Dashboard.php?error=ACCESSDENIED");
        exit();
    }
    $_SESSION["sub_Num"] = $_GET["num"];
    $_SESSION["sub_Dep_Name"] = $_GET["Dep"];
    if($_SESSION["STUDENT"]==1){
        if(getStudentYear($conn)!==getSubjectYear($conn,$_SESSION["sub_Num"],$_SESSION["sub_Dep_Name"])){
            header("location: ../Dashboard.php?error=ACCESSDENIED");
            exit();
        }
    }else if(DoesTeach($conn)==0){
        header("location: ../Dashboard.php?error=ACCESSDENIED");
        exit();
    }
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="../../dist/output.css" rel="stylesheet">
        <link href="index.css" rel="stylesheet">
        <link rel="stylesheet" href="https://unicons.iconscout.com/release/v3.0.6/css/line.css">
        <link rel="stylesheet" href="	https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <title><?php echo ucfirst($_GET["Dep"])?></title>  
        <style>
            html, body {
                max-width: 100%;
                overflow-x: hidden;
            }
        </style>
    </head>
    <body class='bg-gray-800 '>
        
        <div class=' ml-72 h-100  ' style="width:100%" >
            <div class=' relative '>
            <div class="container w-100 d-flex justify-content-center">
                <div class="row align-items-start w-100">
                    <div class="col mr-0">
                        <h1 class='text-gray-400 w-auto h-auto'><?php echo ucfirst($_GET["Dep"])?></h1>
                    </div>
                    <div class="col ml-xl-5">
                        <a href="Subject.php?Dep=<?php echo $_SESSION["sub_Dep_Name"]?>&num=<?php echo $_SESSION["sub_Num"]?>" class="ml-72 ml-xl-72 btn btn-info mt-2" name="new-post">View Posts</a>
                    </div>
                    <div class="col ml-xl-5">
                        <a href="Subject.php?Dep=<?php echo $_SESSION["sub_Dep_Name"]?>&num=<?php echo $_SESSION["sub_Num"]?>&p=1" class="ml-50 ml-xl-50 btn btn-info mt-2" name="new-post">Participants</a>
                    </div>
                    <div class="col">
                        <a href="Subject.php?Dep=<?php echo $_SESSION["sub_Dep_Name"]?>&num=<?php echo $_SESSION["sub_Num"]?>&s=1" class="btn btn-info mt-2" name="new-post">Statistics</a>
                    </div>
                    
                </div>
            </div>
            
            
            <?php
            if(isset($_GET["p"])){
                echo '<div class="shadow card ml-5 w-75">';
                echo '<h5 class="card-header w-100">Participants</h5><div class="card-body">';
                echo '<hr><br>';
                echo '<h2>Teachers</h2>';
                echo '<hr>';
                //teachers
                $i = 1;
                $teachers = getTeachersWhoTeach($conn);
                foreach($teachers as $teacher){
                    echo '<div class="card rounded w-50 ml-5">';
                    echo "<h6>".$i."- ".$teacher."</h6>";
                    echo '</div><br>';
                    $i++;
                }
                echo '<hr>';
                echo '<h2>Students</h2>';
                echo '<hr>';
                $students = getStudentinSubject($conn);
                $i = 1;
                foreach($students as $student){
                    echo '<div class="card rounded w-50 ml-5">';
                    echo "<h6>".$i."- ".$student."</h6>";
                    echo '</div><br>';
                    $i++;
                }
            }else if(isset($_GET["s"])){
                echo '<div class="shadow card ml-5 w-75">';
                echo '<h5 class="card-header w-100">Statistics</h5><div class="card-body">';
                echo '<hr><br>';
                echo '<h2>Past Grades</h2>';
                echo '<hr>';
                $grade_counts = getPastGrades($conn);
                foreach($grade_counts as $gc){
                    echo '<div class="card rounded w-50 ml-5">';
                    echo "<h6>Grade: ".$gc[1]."</h6><h6>Count: ".$gc[2]."</h6>";
                    echo '</div><br>';
                }
            } else {
                $posts = getPosts($conn);
                echo '<div class="d-flex ml-72" style="margin-left:21%">';
                echo '<div class="shadow card w-50">';
                echo '<h5 class="shadow card-header d-flex justify-content-center">New Post</h5>';
                echo '<div class="card-body " style="height:300px;width:100%">';
                echo '<form action="NewPost.inc.php" method="post" style="width:100%">';
                echo '<textarea type="text" name="post-text" placeholder="Write new post..." class="shadow p-0 border border-dark" style="height:201px;width:100%;resize: none;"></textarea>';
                echo '<button class="btn btn-info ml-50 rounded-pill" style="float:right" type="submit" name="new-post"><h4>Post</h4></button>';
                echo '</form></div></div></div><div class="astrodivider" style="margin-left:30%"><div class="astrodividermask"></div><span><i>&#10038;</i></span></div>';
                foreach ($posts as $post) {
                    echo '<div class="shadow card rounded-pill w-75 ml-5 " style="width:100%;height:auto">';
                    echo '<div class="m-4">';
                    echo "<h5 >Posted by: " . $post[2] . "</h5>";
                    echo "<p>Date: " . date_format($post[1], 'c') . "</p>";
                    echo "<hr><p class='ml-4 mt-0 b'>" . $post[0] . "</p>";
                    echo '</div><br></div><hr>';
                    
                }
            }
            ?>
            </div>
        </div>
         






        
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script type="text/javascript"src="script.js"></script>
        
    </body>
</html>