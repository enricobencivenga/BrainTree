export class AppSettings {
    public static API_ENDPOINT='http://localhost:5552/api/braintree';
    public static GET_CLIENT_TOKEN_URL = AppSettings.API_ENDPOINT + '/getclienttoken';
    public static CREATE_PURCHASE_URL = AppSettings.API_ENDPOINT + '/createpurchase';
 }