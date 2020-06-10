import {API_URL} from "@/util/constants"
import axios from 'axios';
import User from "@/models/User"

const client = axios.create({baseURL: API_URL})

export const createNewUser = async (user: User) => {
}

export const getUserById = async (user: User) => {

}
