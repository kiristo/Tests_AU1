using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorFluentCMS.Core
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        Task CreateArticleAsync(Article article);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(int id);
    }
}
