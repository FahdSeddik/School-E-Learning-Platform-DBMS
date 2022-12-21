let header = $(`<div class='flex flex-row'>
<div class="fixed top-0 left-0 h-screen w-72 m-0
    flex flex-col 
    bg-gray-900 text-white shadow   
    //place-content-center
    object-top"> 
    <div class=' mt-0 '>
        <img src='../assets/School_Logo.png' alt="0" />
    </div>
    <div class='pl-6'>
        <a href="../Dashboard.php"
            class='text-sm flex items-center gap-x-4 cursor-pointer 
            bg-slate-400 text-gray-700 mx-4 mt-12 px-3 
            rounded-md'>       
        <img src='../assets/menu/dashboards.png' alt="0" class=' w-8 h-8'/>
        <span>Dashboard</span>
        </a>
        <a href="../Announcement.php"
            class=' text-gray-400 text-sm flex items-center gap-x-4 cursor-pointer 
            hover:bg-slate-400 hover:text-gray-700 mx-4 mt-3 px-3 
            rounded-md'>
    
        <img src='../assets/menu/announcement.png' alt="0" class=' w-8 h-8'/>
        <span>Announcement</span>

        </a>
        <a href="../Schedule.php"
            class=' text-gray-400 text-sm flex items-center gap-x-4 cursor-pointer 
            hover:bg-slate-400 hover:text-gray-700 mx-4 mt-3 px-3 
            rounded-md'>
    
        <img src='../assets/menu/schedule.png' alt="0" class=' w-8 h-8'/>
        <span>Schedule</span>

        </a>
        <a href="../Report.php"
            class=' text-gray-400 text-sm flex items-center gap-x-4 cursor-pointer 
            hover:bg-slate-400 hover:text-gray-700 mx-4 mt-3 px-3 
            rounded-md'>
    
        <img src='../assets/menu/report.png' alt="0" class=' w-8 h-8'/>
        <span>Report</span>

        </a>
        <a href="../Contact.php"
            class=' text-gray-400 text-sm flex items-center gap-x-4 cursor-pointer 
            hover:bg-slate-400 hover:text-gray-700 mx-4 mt-3 px-3 
            rounded-md'>
    
        <img src='../assets/menu/communicate.png' alt="0" class=' w-8 h-8'/>
        <span>Contact School/teacher</span>

        </a>
        <a href="#"
            class=' text-gray-400 text-sm flex items-center gap-x-4 cursor-pointer 
            hover:bg-slate-400 hover:text-gray-700 mx-4 mt-12 px-3 
            rounded-md'>
    
            <img src='../assets/menu/settings.png' alt="0" class=' w-8 h-8'/>
            <span>Settings</span>

        </a>
        <a href="../includes/logout.inc.php"
            class=' text-gray-400 text-sm flex items-center gap-x-4 cursor-pointer 
            hover:bg-slate-400 hover:text-gray-700 mx-4 mt-3 px-3 
            rounded-md'>
    
        <img src='../assets/menu/log-out.png' alt="0" class=' w-8 h-8'/>
        <span class=" text-red-600">Log out</span>

        </a>

    </div>   
</div>
`);

$(document).ready(()=> {
    let bodyElement = $(`body`);
    bodyElement.prepend(header);
});


