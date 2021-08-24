import React, { useEffect, useState } from "react";
// import logo from "./logo.svg";
import "./App.css";
import axios from "axios";
import { Header, Icon, List } from "semantic-ui-react";

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
  }, []); // * Empty array for avoiding infinite state loop
  return (
    <div className='App'>
      <Header as='h2' icon textAlign='center'>
        <Icon name='users' circular />
        <Header.Content>Reactivities</Header.Content>
      </Header>
      <List bulleted>
        {activities.map((activity: any) => (
          <List.Item key={activity.id}>
            {activity.title}
            {/* <label> Date : {activity.date}</label>
                <label> Description : {activity.description}</label>
                <label> Category : {activity.category}</label>
                <label> City : {activity.city}</label>
                <label> Venue : {activity.venue}</label> */}
          </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;

// http://localhost:5000/api/activities
