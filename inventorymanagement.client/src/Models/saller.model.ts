export interface Saller {
  id?: number;
  name: string;
  cnic: string;
  phoneNumber: string;
  address: string;
  documents?: SallerDocument[];
}

export interface SallerDocument {
  id?: number;
  attachmentId: number;
  attachment: Attachment;
}

export interface Attachment {
  id?: number;
  bytes: any;
  description: string;
  fileExtension: string;
  size: number;
}