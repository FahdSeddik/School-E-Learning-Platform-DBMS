import React from 'react'
import {Outlet} from 'react-router-dom'
import SideBar from './SideBar'
function Layout() {
  return (
    <div className='flex flex-row h-screen '>
      <div><SideBar/></div>
      <div className=' ml-72 bg-slate-600'>
        {/* <div className='p-4'>header</div> */}
        <div className='p-4  bg-gray-800 absolute'> {<Outlet />} </div>
      </div>
    </div>
  )
}

export default Layout