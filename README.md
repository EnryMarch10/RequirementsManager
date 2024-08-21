# Requirements Manager

Assignment based on a management application using MySQL and C# of
[Databases - a.y. 2023-2024](https://www.unibo.it/en/teaching/course-unit-catalogue/course-unit/2023/378217)
([Computer Science and Engineering](https://corsi.unibo.it/1cycle/ComputerScienceEngineering)).

## Author

[@EnryMarch10](https://github.com/EnryMarch10)

## Behavior

The system is designed to manage requirements throughout all stages of software development and revision, maintaining
comprehensive records of both finalized and in-progress data related to published or upcoming releases.
The process begins with a Request, from which corresponding Requirements can be developed.

Key functionalities of the system include:

1. **Users and Database Management**: The system administrator is responsible for creating user accounts and linking them to the
   relevant databases associated with the software.

2. **Requests Creation and Development**: Requests may be initiated by team members or customers. Only team members can develop
   Requirements from these Requests. Requests and Requirements can be updated or modified in subsequent releases,
   though tracking every change is not necessary; maintaining accurate final data just before a release is crucial.

3. **Requirement and Request Structuring**:
    - **Requirements** must include a title, type (functional or non-functional), version, description, body, associated files,
      progress data, creation time, and last modified time. It is essential to record the user responsible for the first and last
      modifications and maintain a history of updates.
    - **Requests** must have a title, type, version, description, body, associated files, creation time, and last modified time.
      Similar to Requirements, the first and last modification details and update history must be recorded.

4. **Approval Process**: Each Request must be approved by a team member before it can be developed into a Requirement.
   Post-approval, the customer must accept the request approval before the Requirement can be developed.
   Once approved, Requests cannot be modified.

5. **User Information Management**: User profiles should include username, name, surname, email, phone number, and optionally,
   company name.

6. **Release Management**: Releases must have a short description and a unique name for identification.
   A new timeline can only be created if all associated Requirements are completed.
   Requests must be approved, formalized into Requirements, and finalized before a new version can be created.
   Data modified by a version cannot be overridden, ensuring that all changes are recorded prior to version creation.

Overall, the system ensures structured management of Requests and Requirements, rigorous tracking of modifications,
and proper handling of approvals and releases.

## More

For more info read the [documentation](./doc/report/report.pdf).

## License

[MIT](https://choosealicense.com/licenses/mit/)
