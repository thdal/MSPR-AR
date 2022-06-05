import * as functions from 'firebase-functions';
import * as adminRaw from 'firebase-admin';

adminRaw.initializeApp(functions.config().firebase);
export const admin = adminRaw