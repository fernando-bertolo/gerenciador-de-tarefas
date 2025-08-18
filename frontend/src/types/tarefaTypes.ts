export enum Status {
  Pendente = "Pendente",
  EmProgresso = "EmProgresso",
  Concluida = "Concluida",
  Todos = "",
}

export interface Tarefa {
  codigo: number;
  titulo: string;
  descricao?: string;
  status: Status;
  dataConclusao?: string;
}
