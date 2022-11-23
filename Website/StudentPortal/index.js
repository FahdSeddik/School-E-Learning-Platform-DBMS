// Window Loads
let header = $(`
<div id="navbar" >
    <input type="checkbox" id="check">
        <label for="check">
            <i class="fas fa-bars" id="btn"></i>
            <i class="fas fa-times" id="cancel"></i>
        </label>
    <div class="sidebar">
        <header>Main Menu</header>
        <ul>
            <li><a href="student.php"><i class="fas fa-house"></i>Classes</a></li>
            <li><a href="schedule.php"><i class="fas fa-calendar-week"></i>Schedule</a></li>
            <li><a href="#"><i class="fas fa-envelope"></i>Send E-mail</a></li>
            <li><a href="#"><i class="fas fa-sliders-h"></i>Settings</a></li>
            <li><a href="../includes/logout.inc.php"><i class="fa-solid fa-right-from-bracket"></i>Logout</a></li>
        </ul>
    </div>
</div>
<script>
        // When the user scrolls the page, execute myFunction
        window.onscroll = function() {st()};

        // Get the navbar
        var navbar = document.getElementById("navbar");

        // Get the offset position of the navbar
        var sticky = navbar.offsetTop;

        // Add the sticky class to the navbar when you reach its scroll position. Remove "sticky" when you leave the scroll position
        function st() {
            if (window.pageYOffset >= sticky) {
                navbar.classList.add("sticky")
            } else {
                navbar.classList.remove("sticky");
            }
        }
</script>
`);

$(document).ready(()=> {
    let bodyElement = $(`body`);
    bodyElement.prepend(header);
});
var myVar;
function stopload(){
    myVar = setTimeout(showPage, 3000);
}
function showPage() {
    document.getElementById("loader").style.display = "none";
    let myElements = document.querySelectorAll(".sidebar");

    for (let i = 0; i < myElements.length; i++) {
    	myElements[i].style.zIndex = 5;
    }
}
