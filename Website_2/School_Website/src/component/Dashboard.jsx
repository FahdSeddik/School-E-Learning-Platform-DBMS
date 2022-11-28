import React from 'react'


const Subjects = [

    {name: "English", src:"english.png"},
    {name: "Arabic", src:"arabic.png"},
    {name: "Science", src:"science.png"},
    {name: "Math", src:"math.png" },
    
  ];



const Dashboard = () => {
  return (
    <div className=' relative '>
        <h1 className='text-gray-400'>Dashboard</h1>
        

        <div class="">
            <div class="mx-auto max-w-2xl py-16 px-4 sm:py-24 sm:px-6 lg:max-w-7xl lg:px-8">                
                <div class="grid grid-cols-1 gap-y-10 gap-x-6 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 xl:gap-x-8 ">
                    {Subjects.map((Subject,index) => (
                        <a href="#" class="group" key={index}>
                            <div class="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8">
                            <img src={`../src/assets/subject/${Subject.src}`} alt="0" class="h-full w-full object-cover object-center group-hover:opacity-75"/>
                            </div>
                            <h3 class="mt-4 text-2xl text-gray-400 ">{Subject.name}</h3>
                        </a>

                        
                        ))}
                    </div>
                </div>
        </div>
    </div>
  )
}

export default Dashboard