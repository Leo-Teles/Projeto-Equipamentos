import axios from "axios";

export const LerconteudoDaImagem = async (formData) => {

    let resultado;

     await axios({
        method: "POST",
        url: "https://Ocr-EquipamentosLeoTeles.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data: formData,
        headers: {
            "Content-Type": "multipart/form-data",
            "Ocp-Apim-Subscription-Key": "9e257876f76e47d18f19229134ddd281"
        }
    })
    .then(response => {
        resultado = LerJSON(response.data);
    })
    .catch(erro => console.log(erro))

    return resultado;

}

export const LerJSON = (obj) =>{


    let resultado;

    obj.regions.forEach(regions => {
        regions.lines.forEach(lines => {
            lines.words.forEach(words => {
                if(words.text[0] === "1" && words.text[1] === "2"){
                    resultado = words.text;
                }
            });
            
        });
        
    });



    return resultado;
}