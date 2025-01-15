import openai
import os

def translate_text(text, target_language):
    openai.api_key = os.environ["OPENAI_API_KEY"]
    completion = openai.ChatCompletion.create(
        model="gpt-4o-mini",
        messages=[
            {"role": "system", "content": "You are a helpful assistant."},
            {"role": "user", "content": f"Translate the following text to {target_language}: {text}"}
        ]
    )
    return completion.choices[0].message['content']

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

if __name__ == "__main__":
    main()