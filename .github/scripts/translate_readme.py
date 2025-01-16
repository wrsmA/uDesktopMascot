from openai import OpenAI
import os

client = OpenAI(api_key=os.environ["OPENAI_API_KEY"])

def translate_text(text, target_language):
    completion = client.chat.completions.create(
        model="gpt-4o-mini",  # 使用するモデルの指定
        messages=[
            {"role": "system", "content": "You are a helpful assistant."},
            {"role": "user", "content": f"Translate the following text to {target_language}: {text}"}
        ]
    )
    # メッセージのコンテンツに直接アクセスする
    return completion.choices[0].message.content

def main():
    # Read the original README
    with open('README.md', 'r', encoding='utf-8') as file:
        original_text = file.read()

    # Translate to English
    translated_en = translate_text(original_text, 'English')
    with open('README_EN.md', 'w', encoding='utf-8') as file:
        file.write(translated_en)

    # Translate to Chinese
    translated_cn = translate_text(original_text, 'Chinese')
    with open('README_CN.md', 'w', encoding='utf-8') as file:
        file.write(translated_cn)

    # Translate to Spanish
    translated_es = translate_text(original_text, 'Spanish')
    with open('README_ES.md', 'w', encoding='utf-8') as file:
        file.write(translated_es)

    # Translate to French
    translated_fr = translate_text(original_text, 'French')
    with open('README_FR.md', 'w', encoding='utf-8') as file:
        file.write(translated_fr)

if __name__ == "__main__":
    main()