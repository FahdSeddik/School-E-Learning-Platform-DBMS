<?php
    include_once 'header.php';
    include_once 'LOGCHECK.php';
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
                                <a href="#" class="group">
                                    <div class="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8">
                                    <img src='../src/assets/subject/english.png' alt="0" class="h-full w-full object-cover object-center group-hover:opacity-75"/>
                                    </div>
                                    <h3 class="mt-4 text-2xl text-gray-400 ">English</h3>
                                </a>
                                <a href="#" class="group">
                                    <div class="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8">
                                    <img  src='../src/assets/subject/arabic.png' alt="0" class="h-full w-full object-cover object-center group-hover:opacity-75"/>
                                    </div>
                                    <h3 class="mt-4 text-2xl text-gray-400 ">Arabic</h3>
                                </a>
                                <a href="#" class="group">
                                    <div class="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8">
                                    <img src='../src/assets/subject/math.png' alt="0" class="h-full w-full object-cover object-center group-hover:opacity-75"/>
                                    </div>
                                    <h3 class="mt-4 text-2xl text-gray-400 ">math</h3>
                                </a>
                                <a href="#" class="group">
                                    <div class="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8">
                                    <img src='../src/assets/subject/science.png' alt="0" class="h-full w-full object-cover object-center group-hover:opacity-75" />
                                    </div>
                                    <h3 class="mt-4 text-2xl text-gray-400 ">Science</h3>
                                </a>
                                <a href="#" class="group">
                                    <div class="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8">
                                    <img  src='../src/assets/subject/geography.png' alt="0" class="h-full w-full object-cover object-center group-hover:opacity-75"/>
                                    </div>
                                    <h3 class="mt-4 text-2xl text-gray-400 ">Geography</h3>
                                </a> 
                                   
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="index.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <?php
        if($_SESSION["usersName"]){
            echo '<script>';
            echo '$(document).ready(()=> {';
            echo "    let testtag = '";
            echo '<a href="#" class="group"><div class="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8"><img src="../src/assets/subject/english.png" alt="0" class="h-full w-full object-cover object-center group-hover:opacity-75"/></div><h3 class="mt-4 text-2xl text-gray-400 ">'.$_SESSION["usersName"].'</h3></a>';
            echo "';";
            echo "document.getElementById('add_sub').innerHTML+= testtag;";
            echo '});';
            echo '</script>';
        }
    ?> 
</body>
</html>