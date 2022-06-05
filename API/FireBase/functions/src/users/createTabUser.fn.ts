import * as functions from 'firebase-functions';
import { admin } from '../utils/utils';

export async function createTabUser(usersRecord: any, formData: any){

    try{

        functions.logger.log(`Debut de la création de la table de l'utilisateur ${usersRecord.uid}`)
        functions.logger.log(formData)

        if (usersRecord && formData){
            functions.logger.log(usersRecord)
            functions.logger.log(formData)
            const userDataLink = admin.database().ref(`users/${formData.firstname}`)
            await userDataLink.set(formData)

        }
        else{
            functions.logger.error(`Data manquant pour l'utilsateur ${usersRecord.uid}`)
        }
    }
    catch(e){
        throw e
    }
}