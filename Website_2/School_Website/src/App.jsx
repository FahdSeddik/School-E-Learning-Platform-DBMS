//import styles from "./style";
import React from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Layout  from './component/shared/Layout';
import Dashboard from './component/Dashboard';
import Schedule from './component/Schedule';
import Announcements from './component/Announcements';
import Report_Card from './component/Report_Card';
import Contact from './component/Contact';
import LogIn from './component/LogIn';
//import SideBar from './SideBar';

const App = () => {
 return(
  <Router>
    <Routes>
      <Route path="/" element = {<Layout />}>
        <Route index element={<Dashboard/>}/>
        <Route path='Schedule' element={<Schedule/>}/>
        <Route path='Announcements' element={<Announcements/>}/>
        <Route path='ReportCard' element={<Report_Card/>}/>
        <Route path='ContactSchool/Teacher' element={<Contact/>}/>
      </Route>
      <Route path='Log Out' element={<LogIn/>}/>
    </Routes>
  </Router>
 )
 };


export default App
{/* <div className="flex ">
<SideBar/>
</div> */}


// import { useState } from 'react'
// import reactLogo from './assets/react.svg'
// import './App.css'

// function App() {
//   const [count, setCount] = useState(0)

//   return (
//     <div className="App">
//       <div>
//         <a href="https://vitejs.dev" target="_blank">
//           <img src="/vite.svg" className="logo" alt="Vite logo" />
//         </a>
//         <a href="https://reactjs.org" target="_blank">
//           <img src={reactLogo} className="logo react" alt="React logo" />
//         </a>
//       </div>
//       <h1>Vite + React</h1>
//       <div className="card">
//         <button onClick={() => setCount((count) => count + 1)}>
//           count is {count}
//         </button>
//         <p>
//           Edit <code>src/App.jsx</code> and save to test HMR
//         </p>
//       </div>
//       <p className="read-the-docs">
//         Click on the Vite and React logos to learn more
//       </p>
//     </div>
//   )
// }

// export default App
