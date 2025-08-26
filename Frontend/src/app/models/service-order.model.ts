import {Client} from './client.model';
import {Technician} from './technician.model';

export enum ServiceOrderStatus{
    Pending = 0,
    Open = 1,
    InProgress = 2,
    Completed = 3,
    Canceled = 4
}

export interface ServiceOrder{
    id: number;
    clientId: number;
    client: Client;
    technicianId: number;
    technician: Technician;
    title: string;
    description: string;
    status: ServiceOrderStatus;
}