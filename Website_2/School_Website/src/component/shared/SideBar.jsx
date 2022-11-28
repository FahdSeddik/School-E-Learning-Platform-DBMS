import {useState} from 'react'
import {Link, useLocation} from 'react-router-dom'
//import {dashboards} from './assets';


const Menus = [

  {title: "Dashboard", src:"dashboards.png" , path:'/', gap:true},
  {title: "Announcements", src:"announcement.png" , path:'/Announcements'},
  {title: "Schedule", src:"schedule.png", path:'/Schedule'},
  {title: "Report Card", src:"report.png", path:'/ReportCard'},
  {title: "Contact School/Teacher", src:"communicate.png", path:'/ContactSchool/Teacher' },
  {title: "Settings", src:"settings.png", path: '/Settings', gap:true},
  {title: "Log Out", src: "log-out.png", path:'/Log Out'}
];


const SideBar = () => {
  const location = useLocation()
  const [selected, setselected] = useState(location.pathname.toString());
  console.log('sel ',selected)
  console.log('pathname', location.pathname);
  return (
    <div className="fixed top-0 left-0 h-screen w-72 m-0
                    flex flex-col 
                    bg-gray-900 text-white shadow   
                    //place-content-center
                    object-top"> 
        <div className=' mt-0 '>
          <img src="../src/assets/School_Logo.png" alt="0" />
        </div>
        <ul className='pl-6'>
        {Menus.map((menu,index) => (
               <SideBarLink key={index} item={menu}/>
               
             ))}
          
        </ul>   
    </div>
  );
};

function SideBarLink({item}){
  const {pathname} = useLocation()

  return(
    <Link to= {item.path} className=' items-center'>
                 <li 
                     className = {` text-gray-400 text-sm flex items-center gap-x-4 cursor-pointer 
                     hover:bg-slate-400 hover:text-gray-700 mx-4 px-3 
                     rounded-md ${item.gap? "mt-14" : "mt-3" } 
                     ${(pathname == item.path)? 'bg-slate-400 text-gray-700':''} 
                     ${item.title == 'Log Out'? ' text-red-400': ''}`}>
                  <img src={`../src/assets/menu/${item.src}`} alt="0" className=' w-8 h-8' />
                  <span>{item.title}</span>
                    
                 </li>
    </Link>
  )
}


export default SideBar


// onClick= {()=> 
//   {setselected('/' + menu.title)
//   console.log('/9' + menu.title)}}

        {/* <nav className='relative flex items-center justify-center  mt-2 mx-auto shadow-lg
        bg-gray-900 text-green-600 
        hover:bg-gray-700 hover:text-white
        hover:cursor-pointer'>
          <img src='../src/assets/schedule.png' alt="dashboard" className='w-[64px] h-[64px]' />
          <p>Dashboard</p>
        </nav>           
        <nav className='relative flex items-center justify-center mt-2 mx-auto shadow-lg
         w-52 h-32
        bg-gray-900 text-green-600 
        hover:bg-gray-700 hover:text-white
        hover:cursor-pointer'>
          <img src='../src/assets/report.png' alt="dashboard" className='w-[64px] h-[64px]' />
          <p>Report</p>
        </nav>           */}
        {/* <nav>
          <img src={report} alt="dashboard" />
        </nav>
        <nav>
          <img src={schedule} alt="dashboard" />
        </nav>
        <nav>
          <img src={settings} alt="dashboard" />
        </nav> */}