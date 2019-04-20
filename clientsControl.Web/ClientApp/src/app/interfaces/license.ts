import { ILicenseDetail } from "./license-detail";

export interface ILicense {
  id:string,
  reup: string,
  name: string,
  code: string,
  creationDate: Date,
  descontinued: boolean,
  clientId: string,                
  versionId: string,        
  stockTypeId: string,
  clasificationId: string
  licenseDetail: ILicenseDetail[]
}
