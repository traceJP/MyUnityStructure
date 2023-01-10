using System.Threading.Tasks;
using WorldService.Facades;

namespace WorldService.Controller
{
    public class WorldController
    {
        public void Ctor()
        {
            
        }
        
        public async Task Init()
        {
            // 加载世界资源
            await AllWorldAssets.WorldAssets.LoadAllAssets();
            


        }
        
        
        
    }
}