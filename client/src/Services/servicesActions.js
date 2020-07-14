function getInquickerServices() {
  // GET request using fetch with async/await
  const url = `https://api.inquickerstaging.com/v3/winter.inquickerstaging.com/services`;
  return fetch(url)
    .then(handleErrors)
    .then((response) => {
      return response.json();
    });
  //.then(res => res.data);
}
// Handle HTTP errors since fetch won't.

function handleErrors(response) {
  if (!response.ok) {
    throw Error(response.statusText);
  }
  return response;
}


export function fetchInquickerServices() {
  return dispatch => {
    dispatch(fetchInquickerServicesBegin());
    return getInquickerServices()
      .then(res => {
        dispatch(fetchInquickerServicesSuccess(res.data));
        return res.data;
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
