
// function getInquickerServices() {
//     return fetch("/InquickerServices")
//       .then(handleErrors)
//       .then(res => res.json());
//   }

// Handle HTTP errors since fetch won't.
  
  // function handleErrors(response) {
  //   if (!response.ok) {
  //     throw Error(response.statusText);
  //   }
  //   return response;
  // }
  
  export function fetchInquickerServices() {
    return dispatch => {
      dispatch(fetchInquickerServicesBegin());
      return fakeGetInquickerServices()
        .then(json => {
          dispatch(fetchInquickerServicesSuccess(json.quickerServices));
          return json.quickerServices;
        })
        .catch(error =>
          dispatch(fetchInquickerServicesFailure(error))
        );
    };
  }
  
    
  export const FETCH_INQUICKERSERVICES_BEGIN = "FETCH_INQUICKERSERVICES_BEGIN";
  export const FETCH_INQUICKERSERVICES_SUCCESS = "FETCH_INQUICKERSERVICES_SUCCESS";
  export const FETCH_INQUICKERSERVICES_FAILURE = "FETCH_INQUICKERSERVICES_FAILURE";
  
  export const fetchInquickerServicesBegin = () => ({
    type: FETCH_INQUICKERSERVICES_BEGIN
  });
  
  export const fetchInquickerServicesSuccess = quickerServices => ({
    type: FETCH_INQUICKERSERVICES_SUCCESS,
    payload: { quickerServices }
  });
  
  export const fetchInquickerServicesFailure = error => ({
    type: FETCH_INQUICKERSERVICES_FAILURE,
    payload: { error }
  });
  

  function fakeGetInquickerServices() {
    return new Promise(resolve => {
      // Resolve after a timeout so we can see the loading indicator
      setTimeout(
        () =>
          resolve({
            quickerServices: [
              {
                id: 0,
                name: "Apple"
              },
              {
                id: 1,
                name: "Bananas"
              },
              {
                id: 2,
                name: "Strawberries sample"
              }
            ]
          }),
        1000
      );
    });
  }
  