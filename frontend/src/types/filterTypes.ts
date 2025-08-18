import { Status } from "./tarefaTypes";

export interface Filter {
  search: string;
  status: Status;
}
