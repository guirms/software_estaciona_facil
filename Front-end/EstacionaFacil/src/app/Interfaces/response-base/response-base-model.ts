export interface ResponseBaseModel<T> {
    Sucesso: boolean;
    Mensagem: string;
    Data: T,
}
