import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SallerServiceService } from '../../services/saller-service/saller.service';
import { Saller } from '../../Models/saller.model'

@Component({
  selector: 'app-saller',
  templateUrl: './saller.component.html',
  styleUrls: ['./saller.component.css']
})
export class SallerComponent implements OnInit {
  sallers: Saller[] = [];
  newSaller: Saller = { name: '', cnic: '', phoneNumber: '', address: '', documents: [] };
  selectedSaller: Saller = { name: '', cnic: '', phoneNumber: '', address: '', documents: [] };

  documentFiles: File[] = [];
  updateDocumentFiles: File[] = [];

  showToastFlag = false;
  toastMessage = '';
  toastType: 'success' | 'error' = 'success';
  isLoading = false;

  @ViewChild('updateModal') updateModal: any;

  constructor(private sallerService: SallerServiceService, private modalService: NgbModal) {}

  ngOnInit(): void {
    this.loadSallers();
  }

  loadSallers(): void {
    this.isLoading = true;
    this.sallerService.getSallers().subscribe({
      next: res => {
        this.sallers = res;
        this.isLoading = false;
      },
      error: () => {
        this.toast('Failed to load sellers', 'error');
        this.isLoading = false;
      }
    });
  }

  onDocumentSelected(event: any) {
    this.documentFiles = Array.from(event.target.files);
  }

  onUpdateDocumentSelected(event: any) {
    this.updateDocumentFiles = Array.from(event.target.files);
  }

  saveSaller() {
    const formData = new FormData();
    formData.append('Name', this.newSaller.name);
    formData.append('CNIC', this.newSaller.cnic);
    formData.append('PhoneNumber', this.newSaller.phoneNumber);
    formData.append('Address', this.newSaller.address);

    this.documentFiles.forEach((file, index) => {
      formData.append('documents', file, file.name);
    });

    this.sallerService.createSaller(formData).subscribe({
      next: () => {
        this.toast('Seller created successfully', 'success');
        this.newSaller = { name: '', cnic: '', phoneNumber: '', address: '' };
        this.documentFiles = [];
        this.loadSallers();
      },
      error: () => this.toast('Failed to create seller', 'error')
    });
  }

  openUpdateModal(saller: Saller) {
    this.selectedSaller = { ...saller };
    this.modalService.open(this.updateModal);
  }

  updateSaller(modal: any) {
    const formData = new FormData();
    formData.append('Name', this.selectedSaller.name);
    formData.append('CNIC', this.selectedSaller.cnic);
    formData.append('PhoneNumber', this.selectedSaller.phoneNumber);
    formData.append('Address', this.selectedSaller.address);

    this.updateDocumentFiles.forEach((file, index) => {
      formData.append('documents', file, file.name);
    });

    this.sallerService.updateSaller(this.selectedSaller.id!, formData).subscribe({
      next: () => {
        this.toast('Seller updated successfully', 'success');
        this.loadSallers();
        modal.close();
      },
      error: () => this.toast('Failed to update seller', 'error')
    });
  }

  toast(message: string, type: 'success' | 'error') {
    this.toastMessage = message;
    this.toastType = type;
    this.showToastFlag = true;
  }
}
