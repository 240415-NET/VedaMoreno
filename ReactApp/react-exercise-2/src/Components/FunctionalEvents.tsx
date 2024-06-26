import { click } from '@testing-library/user-event/dist/click';
import React, {useState} from 'react';


function Events() {
//function to be called on a click event
function clickEventHandler(){

  Console.log(click);
}



  return (
    <div>Events</div>

  )
}

export default Events;