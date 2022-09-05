
import { Swagger, TypeInfo, PropertyInfo, MethodInfo, PathInfo } from '../models/swagger-models';

export function genApiEndpoint(methodInfo: MethodInfo, path: string): string {
    
    return `public ${methodInfo.operationId}(): Observable<any>{
        return this.httpClient.${methodInfo.name}<any>('${path}');
    }`;
}

export function genApiClient(swagger: Swagger): string {
    let code = `

@Injectable()
export class ApiClient {
  public constructor(
    httpClient: HttpClient,
    @Optional()
    @InjectionToken('API_URL_BASE')
    public apiUrlBase: string) {
  }
  
  public url(relativeUrl: string): string {
      return this.apiUrlBase + relativeUrl;
  }
  
  `;

    code += `
    ` + Object.keys(swagger.paths).map(path => {
        const pathInfo = swagger.paths[path];

        return Object.keys(pathInfo).map(method => {
            const methodInfo = pathInfo[method];
            methodInfo.name = method;

            return genApiEndpoint(methodInfo, path);
        }).join(`
        `);

    }).join(`
    `);

    return code + `
}`;
}
