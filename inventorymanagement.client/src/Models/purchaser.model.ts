export interface PurchaserDocumentsDTO {
  id?: number;
  documentName?: string;
  documentUrl?: string;
}

export interface SalePurchaseDTO {
  id?: number;
  propertyName?: string;
  salePrice?: number;
  purchaseDate?: string;
}

export interface PurchaserDTO {
  name?: string;
  cnic?: string;
  phoneNumber?: string;
  address?: string;
  documents: PurchaserDocumentsDTO[];
  properties: SalePurchaseDTO;
}
