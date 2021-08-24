import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from "axios";

// Todo : Read Axios and Promise MDN

function App() {
  const [activities, setActivities] = useState([]);
  useEffect(() => {
    axios.get("http://localhost:5000/api/activities").then((response) => {
      console.log(response);
      setActivities(response.data);
    });
    // return () => {
    //   cleanup;
    // };
  }, []);
  return (
    <div className='App'>
      <header className='App-header'>
        <img src={logo} className='App-logo' alt='logo' />
        <ul>
          {activities.map((activity: any) => (
            <li key={activity.id}>
              <label> Title : {activity.title}</label>
              <label> Date : {activity.date}</label>
              <label> Description : {activity.description}</label>
              <label> Category : {activity.category}</label>
              <label> City : {activity.city}</label>
              <label> Venue : {activity.venue}</label>
            </li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;

// http://localhost:5000/api/activities
