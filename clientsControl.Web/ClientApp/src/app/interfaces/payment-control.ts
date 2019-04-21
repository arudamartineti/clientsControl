export interface IPaymentControl {
  id: string,
  generatedDate: Date,
  expirationDate: Date,
  licenceId: string,  
  sendByEmail: boolean,
  sentByEmail: boolean,
  sentByEmailDate: Date,
  licenseName: string,
  clientDescription: string
}
