
export const LOGOUT = 'LOGOUT';
export const CLEAR_SCHEDULE = 'CLEAR_SCHEDULE';


export const LOGIN_REQUEST = 'LOGIN_REQUEST';
export const LOGIN_SUCCESS = 'LOGIN_SUCCESS';
export const LOGIN_ERROR = 'LOGIN_ERROR';

export const EVENTS_REQUEST = 'EVENTS_REQUEST';
export const EVENTS_SUCCESS = 'EVENTS_SUCCESS';
export const EVENTS_ERROR = 'EVENTS_ERROR';


export const EVENT_FOR_ROSTER_REQUEST = 'EVENT_FOR_ROSTER_REQUEST';
export const EVENT_FOR_ROSTER_SUCCESS = 'EVENT_FOR_ROSTER_SUCCESS';
export const EVENT_FOR_ROSTER_ERROR = 'EVENT_FOR_ROSTER_ERROR';



export const EVENT_BY_ID_REQUEST = 'EVENT_BY_ID_REQUEST';
export const EVENT_BY_ID_SUCCESS = 'EVENT_BY_ID_SUCCESS';
export const EVENT_BY_ID_ERROR = 'EVENT_BY_ID_ERROR';

export const EVENT_DETAILS_REQUEST = 'EVENT_DETAILS_REQUEST';
export const EVENT_DETAILS_SUCCESS = 'EVENT_DETAILS_SUCCESS';
export const EVENT_DETAILS_ERROR = 'EVENT_DETAILS_ERROR';

export const EVENT_DETAILS_BY_ID_REQUEST = 'EVENT_DETAILS_BY_ID_REQUEST';
export const EVENT_DETAILS_BY_ID_SUCCESS = 'EVENT_DETAILS_BY_ID_SUCCESS';
export const EVENT_DETAILS_BY_ID_ERROR = 'EVENT_DETAILS_BY_ID_ERROR';

export const SAVE_EVENTS_REQUEST = 'SAVE_EVENTS_REQUEST';
export const SAVE_EVENTS_SUCCESS = 'SAVE_EVENTS_SUCCESS';
export const SAVE_EVENTS_ERROR = 'SAVE_EVENTS_ERROR';


export const SAVE_EVENT_SCHEDULE_REQUEST = 'SAVE_EVENT_SCHEDULE_REQUEST';
export const SAVE_EVENT_SCHEDULE_SUCCESS = 'SAVE_EVENT_SCHEDULE_SUCCESS';
export const SAVE_EVENT_SCHEDULE_ERROR = 'SAVE_EVENT_SCHEDULE_ERROR';

export const EVENT_BOOKING_REQUEST = 'EVENT_BOOKING_REQUEST';
export const EVENT_BOOKING_SUCCESS = 'EVENT_BOOKING_SUCCESS';
export const EVENT_BOOKING_ERROR = 'EVENT_BOOKING_ERROR';

export const LIST_SCHEDULE_REQUEST = 'LIST_SCHEDULE_REQUEST';
export const LIST_SCHEDULE_SUCCESS = 'LIST_SCHEDULE_SUCCESS';
export const LIST_SCHEDULE_ERROR = 'LIST_SCHEDULE_ERROR';

export const EVENT_SCHEDULE_BY_ID_REQUEST = 'EVENT_SCHEDULE_BY_ID_REQUEST';
export const EVENT_SCHEDULE_BY_ID_SUCCESS = 'EVENT_SCHEDULE_BY_ID_SUCCESS';
export const EVENT_SCHEDULE_BY_ID_ERROR = 'EVENT_SCHEDULE_BY_ID_ERROR';

export const BOOKING_DETAILS_REQUEST = 'BOOKING_DETAILS_REQUEST';
export const BOOKING_DETAILS_SUCCESS = 'BOOKING_DETAILS_SUCCESS';
export const BOOKING_DETAILS_ERROR = 'BOOKING_DETAILS_ERROR';

export const PAYMENT_REQUEST = 'PAYMENT_REQUEST';
export const PAYMENT_SUCCESS = 'PAYMENT_SUCCESS';
export const PAYMENT_ERROR = 'PAYMENT_ERROR';


export const FETCH_BOOKING_REQUEST = 'FETCH_BOOKING_REQUEST';
export const FETCH_BOOKING_SUCCESS = 'FETCH_BOOKING_SUCCESS';
export const FETCH_BOOKING_ERROR = 'FETCH_BOOKING_ERROR';

export const FETCH_ORDERS_REQUEST = 'FETCH_ORDERS_REQUEST';
export const FETCH_ORDERS_SUCCESS = 'FETCH_ORDERS_SUCCESS';
export const FETCH_ORDERS_ERROR = 'FETCH_ORDERS_ERROR';

export const FETCH_ORDER_BY_ID_REQUEST = 'FETCH_ORDER_BY_ID_REQUEST';
export const FETCH_ORDER_BY_ID_SUCCESS = 'FETCH_ORDER_BY_ID_SUCCESS';
export const FETCH_ORDER_BY_ID_ERROR = 'FETCH_ORDER_BY_ID_ERROR';


export const FETCH_BOOKING_BY_SLOAT_ID_REQUEST = 'FETCH_BOOKING_BY_SLOAT_ID_REQUEST';
export const FETCH_BOOKING_BY_SLOAT_ID_SUCCESS = 'FETCH_BOOKING_BY_SLOAT_ID_SUCCESS';
export const FETCH_BOOKING_BY_SLOAT_ID_ERROR = 'FETCH_BOOKING_BY_SLOAT_ID_ERROR';


export const IMAGE_PATH = 'https://localhost:44306/EventImage/';


//To encypt single data
export function encryptSingleData(encData) {
    if (encData) {
      var retData = btoa((encData + 122354125410));
      return retData;
    }
  }
  
  //To Decrypt single data
  export function decryptSingleData(encData) {
    if (encData) {
      var smp = atob(encData);
      if ((smp)) {
        var retData = atob(encData) - 122354125410;
        return retData
      }
    }
  }