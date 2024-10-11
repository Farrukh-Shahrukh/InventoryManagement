import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Expense } from '../../Models/expense.model';
import { ExpenseService } from '../../services/expense-service/expense.service';
import { ActivatedRoute } from '@angular/router';
import { ExpenseTypeService } from '../../services/expenseType-service/expense-type.service';
import { ExpenseType } from '../../Models/expenseType.model';
import { ProjectService } from '../../services/project-service/project.service'; // Import ProjectService
import { Project } from '../../Models/project.model'; // Import Project Model
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-expense',
  templateUrl: './expense.component.html',
})
export class ExpenseComponent implements OnInit {
  @ViewChild('updateModal') updateModal!: TemplateRef<any>;
  public expenses: Expense[] = [];
  public newExpense: Expense = new Expense();
  public isEditing: boolean = false;
  public projectId: number = 0;
  public projectName: string = ''; // For read-only project name
  public expenseTypes: { id: number, name: string }[] = [];
  public projects: { id: number, name: string }[] = []; // For project dropdown
  public selectedExpense: Expense = new Expense();

  toastMessage: string = '';
  showToastFlag: boolean = false;
  toastType: string = '';
  isLoading: boolean = false;

  constructor(
    private expenseService: ExpenseService,
    private route: ActivatedRoute,
    private expenseTypeService: ExpenseTypeService,
    private projectService: ProjectService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.projectId = +params['projectId'];
      this.projectName = params['projectName'] || '';
      
      if (!this.projectId) {
        // Load the projects if no projectId is passed
        this.loadProjects();
      }
    });

    this.loadExpenses();
    this.loadExpenseTypes();
  }

  loadProjects(): void {
    this.isLoading = true;
    this.projectService.getProjects().subscribe(
      (data: Project[]) => {
        this.projects = data.map(project => ({ id: project.id, name: project.name }));
        this.isLoading = false;
      },
      error => {
        this.showToast('Error loading projects', 'error');
        this.isLoading = false;
      }
    );
  }

  loadExpenses(): void {
    this.isLoading = true;
    this.expenseService.getExpenses().subscribe(
      (data: Expense[]) => {
        this.expenses = data;
        if(this.projectId)
          this.expenses = data.filter(expense => expense.projectId === this.projectId);
        this.isLoading = false;
      },
      error => {
        this.showToast('Error loading expenses', 'error');
        this.isLoading = false;
      }
    );
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

  saveExpense(): void {
    // Ensure projectId is selected either via queryParams or dropdown
    if (!this.projectId && this.newExpense.projectId === 0) {
      this.showToast('Please select a project.', 'error');
      return;
    }
  
    // Assign projectId from queryParams if available, otherwise use the one selected from the dropdown
    this.newExpense.projectId = this.projectId || this.newExpense.projectId;
  
    this.expenseService.createExpense(this.newExpense).subscribe(
      (newExpense: Expense) => {
        this.expenses.push(newExpense); // Add the newly created expense to the list
        this.resetForm(); // Reset form fields after adding
        this.showToast('Expense added successfully!', 'success'); // Show success toast
      },
      (error) => {
        console.error('Error creating expense', error);
        this.showToast('Error creating expense. Please try again.', 'error'); // Show error toast
      }
    );
  }
  updateExpense(modal: any): void {
    this.expenseService.updateExpense(this.selectedExpense.id, this.selectedExpense).subscribe(
      (response) => {
        this.showToast('Expense updated successfully!', 'success'); // Show success toast
        modal.close(); // Close modal after update
        this.loadExpenses(); // Reload the list of expenses
      },
      (error) => {
        console.error('Error updating expense', error);
        this.showToast('Error updating expense. Please try again.', 'error'); // Show error toast
      }
    );
  }

  deleteExpense(id: number): void {
    this.expenseService.deleteExpense(id).subscribe(
      () => {
        this.showToast('Expense deleted successfully', 'success');
        this.loadExpenses();
      },
      error => this.showToast('Error deleting expense', 'error')
    );
  }

  resetForm(): void {
    this.newExpense = new Expense();
    this.isEditing = false;
  }

  showToast(message: string, type: string): void {
    this.toastMessage = message;
    this.toastType = type;
    this.showToastFlag = true;
    setTimeout(() => this.showToastFlag = false, 3000);
  }
  openUpdateModal(expense: Expense): void {
    this.selectedExpense = { ...expense };
    this.modalService.open(this.updateModal);
    this.isEditing = true;
  }
  getTotalExpenseAmount(): number {
    return this.expenses.reduce((total, expense) => total + expense.amount, 0);
  }  
}
