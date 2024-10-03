import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ExpenseType } from '../../Models/expenseType.model'; // Assuming you have this model
import { ExpenseTypeService } from '../../services/expenseType-service/expense-type.service'; // Assuming you have this service
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-expense-type',
  templateUrl: './expense-type.component.html',
})
export class ExpenseTypeComponent implements OnInit {
  @ViewChild('updateModal') updateModal!: TemplateRef<any>;
  public expenseTypes: ExpenseType[] = [];
  public newExpenseType: ExpenseType = new ExpenseType();
  public selectedExpenseType: ExpenseType = new ExpenseType();
  public isEditing: boolean = false;
  toastMessage: string = '';
  showToastFlag: boolean = false;
  toastType: string = '';
  isLoading: boolean = false;

  constructor(
    private expenseTypeService: ExpenseTypeService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.loadExpenseTypes();
  }

  loadExpenseTypes(): void {
    this.isLoading = true;
    this.expenseTypeService.getExpenseTypes().subscribe(
      (data: ExpenseType[]) => {
        this.expenseTypes = data;
        this.isLoading = false;
      },
      error => {
        this.showToast('Error loading expense types', 'error');
        this.isLoading = false;
      }
    );
  }

  saveExpenseType(): void {
    this.expenseTypeService.createExpenseType(this.newExpenseType).subscribe(
      (newExpenseType: ExpenseType) => {
        this.expenseTypes.push(newExpenseType); // Add the newly created expense type to the list
        this.resetForm(); // Reset form fields after adding
        this.showToast('Expense type added successfully!', 'success'); // Show success toast
      },
      (error) => {
        console.error('Error creating expense type', error);
        this.showToast('Error creating expense type. Please try again.', 'error'); // Show error toast
      }
    );
  }

  updateExpenseType(modal: any): void {
    this.expenseTypeService.updateExpenseType(this.selectedExpenseType.id, this.selectedExpenseType).subscribe(
      (response) => {
        this.showToast('Expense type updated successfully', 'success'); // Show success toast
        modal.close(); // Close modal after update
        this.loadExpenseTypes(); // Reload the list of expense types
      },
      (error) => {
        this.showToast('Error updating expense type', 'error'); // Show error toast
      }
    );
  }
  
  editExpenseType(expenseType: ExpenseType): void {
    this.newExpenseType = { ...expenseType };
    this.isEditing = true;
  }

  deleteExpenseType(id: number): void {
    this.expenseTypeService.deleteExpenseType(id).subscribe(
      () => {
        this.showToast('Expense type deleted successfully', 'success');
        this.loadExpenseTypes();
      },
      error => this.showToast('Error deleting expense type', 'error')
    );
  }

  resetForm(): void {
    this.newExpenseType = new ExpenseType();
    this.isEditing = false;
  }
  openUpdateModal(expenseType: ExpenseType): void {
    this.selectedExpenseType = { ...expenseType };
    this.modalService.open(this.updateModal);
    this.isEditing = true;
  }

  showToast(message: string, type: string): void {
    this.toastMessage = message;
    this.toastType = type;
    this.showToastFlag = true;
    setTimeout(() => this.showToastFlag = false, 3000);
  }
}
