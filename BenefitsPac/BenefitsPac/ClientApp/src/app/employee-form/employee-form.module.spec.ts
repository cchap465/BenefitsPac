import { EmployeeFormModule } from './employee-form.module';

describe('EmployeeFormModule', () => {
  let employeeFormModule: EmployeeFormModule;

  beforeEach(() => {
    employeeFormModule = new EmployeeFormModule();
  });

  it('should create an instance', () => {
    expect(employeeFormModule).toBeTruthy();
  });
});
